using Lab.Domain.Core.Models;
using Lab.Domain.Meetups;
using System;
using System.Collections.Generic;
namespace Lab.Domain.Organizers
{
    public class Organizer : Entity<Organizer>
    {
        public Organizer(Guid id, string name, string document, string email)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
        }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        protected Organizer() { } 
        public virtual ICollection<Meetup> Eventos { get; set; }
        public override bool IsValid()
        {
            return true;
        }
    }
}
