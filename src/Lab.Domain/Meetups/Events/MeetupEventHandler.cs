using Lab.Domain.Core.Events.Interfaces;
using System;

namespace Lab.Domain.Meetups.Events
{
    public class MeetupEventHandler :
        IHandler<MeetupRegisteredEvent>,
        IHandler<MeetupUpdatedEvent>,
        IHandler<MeetupRemovedEvent>,
        IHandler<RegisteredMeetingMeetupAddress>,
        IHandler<AddressMeetupUpdatedEvent>
    {
        public void Handle(MeetupRegisteredEvent message)
        {
            /*
              * A implementação deste evento ficará a disposição do cliente
              * Pois no disparo do evento poderá realizar diversas tarefas como por exemplo:
              * Envio de email
              * Criar arquivo de log
              * Disparar SMS
              * Gerar arquivo para auditorio e entre outros
             */
            throw new NotImplementedException();
        }

        public void Handle(MeetupUpdatedEvent message)
        {
            /*
              * A implementação deste evento ficará a disposição do cliente
              * Pois no disparo do evento poderá realizar diversas tarefas como por exemplo:
              * Envio de email
              * Criar arquivo de log
              * Disparar SMS
              * Gerar arquivo para auditorio e entre outros
             */
            throw new NotImplementedException();
        }

        public void Handle(MeetupRemovedEvent message)
        {
            /*
              * A implementação deste evento ficará a disposição do cliente
              * Pois no disparo do evento poderá realizar diversas tarefas como por exemplo:
              * Envio de email
              * Criar arquivo de log
              * Disparar SMS
              * Gerar arquivo para auditorio e entre outros
             */
            throw new NotImplementedException();
        }

        public void Handle(RegisteredMeetingMeetupAddress message)
        {
            /*
              * A implementação deste evento ficará a disposição do cliente
              * Pois no disparo do evento poderá realizar diversas tarefas como por exemplo:
              * Envio de email
              * Criar arquivo de log
              * Disparar SMS
              * Gerar arquivo para auditorio e entre outros
             */
            throw new NotImplementedException();
        }

        public void Handle(AddressMeetupUpdatedEvent message)
        {
            /*
              * A implementação deste evento ficará a disposição do cliente
              * Pois no disparo do evento poderá realizar diversas tarefas como por exemplo:
              * Envio de email
              * Criar arquivo de log
              * Disparar SMS
              * Gerar arquivo para auditorio e entre outros
             */
            throw new NotImplementedException();
        }
    }
}
