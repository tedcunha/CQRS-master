using AutoMapper;
using Lab.Application.Interfaces;
using Lab.Application.ViewModels;
using Lab.Domain.Core.Bus;
using Lab.Domain.Core.Notifications;
using Lab.Domain.Core.Notifications.Interfaces;
using Lab.Domain.Interfaces;
using Lab.Domain.Meetups.Commands;
using Lab.Domain.Meetups.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lab.Service.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class MeetupsController : BaseController
    {
        private readonly IEventoAppService _meetupAppService;
        private readonly IBus _bus;
        private readonly IMeetupRepository _meetupRepository;
        private readonly IMapper _mapper;
        protected MeetupsController(IDomainNotificationHandler<DomainNotification> notifications, IUser user, IBus bus, IMeetupRepository meetupRepository, IEventoAppService meetupAppService, IMapper mapper) : base(notifications, user, bus)
        {
            _meetupAppService = meetupAppService;
            _meetupRepository = meetupRepository;
            _mapper = mapper;
            _bus = bus;
        }
        [HttpGet]
        [Route("eventos")]
        [AllowAnonymous]
        public IEnumerable<MeetupViewModel> Get()
        {
            return _meetupAppService.GetAll();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos/{id:guid}")]
        public MeetupViewModel Get(Guid id, int version)
        {
            return _meetupAppService.GetById(id);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("eventos/categorias")]
        public IEnumerable<CategoryViewModel> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(_meetupRepository.GetCategory());
        }

        [HttpPost]
        [Route("eventos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Post([FromBody]MeetupViewModel meetupViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var eventoCommand = _mapper.Map<RegisterMeetupCommand>(meetupViewModel);

            _bus.SendCommand(eventoCommand);
            return Response(eventoCommand);
        }

        [HttpPut]
        [Route("eventos")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Put([FromBody]MeetupViewModel meetupViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            _meetupAppService.Update(meetupViewModel);
            return Response(meetupViewModel);
        }

        [HttpDelete]
        [Route("eventos/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Delete(Guid id)
        {
            _meetupAppService.Remove(id);
            return Response();
        }
    }
}