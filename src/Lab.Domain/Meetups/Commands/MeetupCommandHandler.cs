using Lab.Domain.CommandHandlers;
using Lab.Domain.Core.Bus;
using Lab.Domain.Core.Events.Interfaces;
using Lab.Domain.Core.Notifications;
using Lab.Domain.Core.Notifications.Interfaces;
using Lab.Domain.Interfaces;
using Lab.Domain.Meetups.Events;
using Lab.Domain.Meetups.Interfaces.Repositories;
using System;

namespace Lab.Domain.Meetups.Commands
{
    public class MeetupCommandHandler : CommandHandler,
        IHandler<RegisterMeetupCommand>,
        IHandler<UpdateMeetupCommand>,
        IHandler<RemoveMeetupCommand>,
        IHandler<IncludeAddressMeetupCommand>,
        IHandler<UpdateAddressMeetupCommand>
    {
        private readonly IMeetupRepository _meetupRepository;
        private readonly IBus _bus;
        private readonly IUser _user;
        public MeetupCommandHandler(IMeetupRepository meetupRepository,
                                    IUnitOfWork uow,
                                    IDomainNotificationHandler<DomainNotification> notifications,
                                    IBus bus, IUser user) : base(uow, bus, notifications)
        {
            _meetupRepository = meetupRepository;
            _bus = bus;
            _user = user;
        }
        public void Handle(RegisterMeetupCommand message)
        {
            var address = new Address(message.Address.Id, message.Address.Street, message.Address.Number, message.Address.Complement,
                                        message.Address.Neighborhood, message.Address.CEP,  message.Address.City,
                                        message.Address.State, message.Address.MeetupId.Value);

            var meetup = Meetup.MeetupFactory.NewMeetupComplet(
                                                                message.Id, message.Name, message.ShortDescription, message.LongDescription,
                                                                message.DateHome,message.EndDate, message.Free, message.MeetupValue,
                                                                message.Online, message.CompanyName, message.OrganizerId,address, message.CategoryId);
            if (!MeetupIsValid(meetup)) return;
            #region
            // TODO:
            // Validacoes de negocio!
            // Organizador pode registrar evento?
            #endregion
            _meetupRepository.Add(meetup);
            if (Commit())
            {               
                _bus.RaiseEvent(new MeetupRegisteredEvent(meetup.Id, meetup.Name, meetup.DateHome, meetup.EndDate, meetup.Free, meetup.MeetupValue,
                                                          meetup.Online, meetup.CompanyName));
            }
        }
        public void Handle(UpdateMeetupCommand message)
        {
            var AtualMeetup = _meetupRepository.GetById(message.Id);

            if (!ExistingMeetup(message.Id, message.MessageType)) return;

            if (AtualMeetup.OrganizerId != _user.GetUserId())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Evento não pertencente ao Organizador"));
                return;
            }
            var meetup = Meetup.MeetupFactory.NewMeetupComplet(message.Id, message.Name, message.ShortDescription, message.LongDescription,
                                                               message.DateHome, message.EndDate, message.Free, message.MeetupValue,
                                                               message.Online, message.CompanyName, message.OrganizerId, AtualMeetup.Address, message.CategoryId);

            if (!meetup.Online && meetup.Address == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possivel atualizar um evento sem informar o endereço"));
                return;
            }

            if (!MeetupIsValid(meetup)) return;

            _meetupRepository.Update(meetup);

            if (Commit())
            {
                _bus.RaiseEvent(new MeetupUpdatedEvent(meetup.Id, meetup.Name, meetup.ShortDescription, meetup.LongDescription, meetup.DateHome, meetup.EndDate, meetup.Free, meetup.MeetupValue, meetup.Online, meetup.CompanyName));
            }
        }
        public void Handle(RemoveMeetupCommand message)
        {
            if (!ExistingMeetup(message.Id, message.MessageType)) return;

            var atualMeetup = _meetupRepository.GetById(message.Id);

            if (atualMeetup.OrganizerId != _user.GetUserId())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Evento não pertencente ao Organizador"));
                return;
            }
            // Validacoes de negocio
            atualMeetup.RemoveMeetup();
            _meetupRepository.Update(atualMeetup);
            if (Commit())
            {
                _bus.RaiseEvent(new MeetupRemovedEvent(message.Id));
            }
        }
        public void Handle(IncludeAddressMeetupCommand message)
        {           
            var address = new Address(message.Id, message.Street, message.Number, message.Complement,
                                        message.Neighborhood, message.CEP, message.City,
                                        message.State, message.MeetupId.Value);
            if (!address.IsValid())
            {
                NotificarValidacoesErro(address.ValidationResult);
                return;
            }
            _meetupRepository.AddAddress(address);
            if (Commit())
            {
                _bus.RaiseEvent(new RegisteredMeetingMeetupAddress(address.Id, address.Street, address.Number, address.Complement, address.Neighborhood, address.CEP, address.City, address.State, address.MeetupId.Value));
            }
        }
        public void Handle(UpdateAddressMeetupCommand message)
        {
            var address = new Address(message.Id, message.Street, message.Number, message.Complement,
                                        message.Neighborhood, message.CEP, message.City,
                                        message.State, message.MeetupId.Value);
            if (!address.IsValid())
            {
                NotificarValidacoesErro(address.ValidationResult);
                return;
            }
            _meetupRepository.UpdateAddress(address);

            if (Commit())
            {
                _bus.RaiseEvent(new AddressMeetupUpdatedEvent(address.Id, address.Street, address.Number, address.Complement, address.Neighborhood, address.CEP, address.City, address.State, address.MeetupId.Value));
            }
        }
        private bool MeetupIsValid(Meetup meetup)
        {
            if (meetup.IsValid()) return true;
            NotificarValidacoesErro(meetup.ValidationResult);
            return false;
        }
        private bool ExistingMeetup(Guid id, string messageType)
        {
            var meetup = _meetupRepository.GetById(id);
            if (meetup != null) return true;
            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado."));
            return false;
        }       
    }
}
