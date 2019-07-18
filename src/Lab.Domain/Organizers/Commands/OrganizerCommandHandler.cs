using Lab.Domain.CommandHandlers;
using Lab.Domain.Core.Bus;
using Lab.Domain.Core.Events.Interfaces;
using Lab.Domain.Core.Notifications;
using Lab.Domain.Core.Notifications.Interfaces;
using Lab.Domain.Interfaces;
using Lab.Domain.Organizers.Events;
using Lab.Domain.Organizers.Interfaces.Repositories;
using System.Linq;

namespace Lab.Domain.Organizers.Commands
{
    public class OrganizerCommandHandler : CommandHandler,
        IHandler<RegisterOrganizerCommand>
    {
        private readonly IBus _bus;
        private readonly IOrganizerRepository _organizadorRepository;
        public OrganizerCommandHandler(
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IOrganizerRepository organizadorRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _organizadorRepository = organizadorRepository;
        }
        public void Handle(RegisterOrganizerCommand message)
        {
            var organizador = new Organizer(message.Id, message.Name, message.Document, message.Email);

            if (!organizador.IsValid())
            {
                NotificarValidacoesErro(organizador.ValidationResult);
                return;
            }

            var organizadorExistente = _organizadorRepository.Search(o => o.Document == organizador.Document || o.Email == organizador.Email);

            if (organizadorExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _organizadorRepository.Add(organizador);

            if (Commit())
            {
                _bus.RaiseEvent(new OrganizerRegisteredEvent(organizador.Id, organizador.Name, organizador.Document, organizador.Email));
            }
        }
    }
}
