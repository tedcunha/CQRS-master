using AutoMapper;
using Lab.Application.Interfaces;
using Lab.Application.ViewModels;
using Lab.Domain.Core.Bus;
using Lab.Domain.Organizers.Commands;
using Lab.Domain.Organizers.Interfaces.Repositories;

namespace Lab.Application.Services
{
    public class OrganizerAppService : IOrganizerAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrganizerRepository _organizadorRepository;
        private readonly IBus _bus;
        public OrganizerAppService(IMapper mapper, IOrganizerRepository organizadorRepository, IBus bus)
        {
            _mapper = mapper;
            _organizadorRepository = organizadorRepository;
            _bus = bus;
        }
        public void Dispose()
        {
            _organizadorRepository.Dispose();
        }
        public void Register(OrganizerViewModel organizerViewModel)
        {            
            var registerCommand = _mapper.Map<RegisterOrganizerCommand>(organizerViewModel);
            _bus.SendCommand(registerCommand);
        }
    }
}
