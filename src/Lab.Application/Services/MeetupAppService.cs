using AutoMapper;
using Lab.Application.Interfaces;
using Lab.Application.ViewModels;
using Lab.Domain.Core.Bus;
using Lab.Domain.Interfaces;
using Lab.Domain.Meetups.Commands;
using Lab.Domain.Meetups.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Lab.Application.Services
{
    public class MeetupAppService : IEventoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IMeetupRepository _meetupRepository;
        private readonly IUser _user;
        public MeetupAppService(IBus bus, IMapper mapper, IMeetupRepository meetupRepository, IUser user)
        {
            _bus = bus;
            _mapper = mapper;
            _meetupRepository = meetupRepository;
            _user = user;
        }
        public void AddAddress(AddressViewModel addressViewModel)
        {
            var addressCommand = _mapper.Map<IncludeAddressMeetupCommand>(addressViewModel);
            _bus.SendCommand(addressCommand);
        }
        public void Update(MeetupViewModel meetupViewModel)
        {
            var updateMeetupCommand = _mapper.Map<UpdateMeetupCommand>(meetupViewModel);
            _bus.SendCommand(updateMeetupCommand);
        } 
        public AddressViewModel GetAddressById(Guid id)
        {
            return _mapper.Map<AddressViewModel>(_meetupRepository.GetAddressById(id));
        }
        public IEnumerable<MeetupViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<MeetupViewModel>>(_meetupRepository.GetAll());
        }
        public MeetupViewModel GetById(Guid id)
        {
            return _mapper.Map<MeetupViewModel>(_meetupRepository.GetById(id));
        }
        public IEnumerable<MeetupViewModel> GetMeetupByOrganizer(Guid organizerId)
        {
            return _mapper.Map<IEnumerable<MeetupViewModel>>(_meetupRepository.GetMeetupOrganizer(organizerId));
        }
        public void Register(MeetupViewModel meetupViewModel)
        {
            var registerCommand = _mapper.Map<RegisterMeetupCommand>(meetupViewModel);
            _bus.SendCommand(registerCommand);
        }
        public void Remove(Guid id)
        {
            _bus.SendCommand(new RemoveMeetupCommand(id));
        }
        public void UpdateAddress(AddressViewModel addressViewModel)
        {
            var addressCommand = _mapper.Map<UpdateAddressMeetupCommand>(addressViewModel);
            _bus.SendCommand(addressCommand);
        }
        public void Dispose()
        {
            _meetupRepository.Dispose();
        }
    }
}
