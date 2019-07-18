using Lab.Domain.Core.Events.Interfaces;
using System;
namespace Lab.Domain.Organizers.Events
{
    public class OrganizerMeetupHandler :
        IHandler<OrganizerRegisteredEvent>
    {
        public void Handle(OrganizerRegisteredEvent message)
        {
            // TODO: Enviar um email            
        }
    }
}
