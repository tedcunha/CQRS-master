using Lab.Domain.Core.Events;
using System;

namespace Lab.Domain.Organizers.Events
{
    public class OrganizerRegisteredEvent : Event
    {
        public OrganizerRegisteredEvent(Guid id, string name, string document, string email)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }

    }
}
