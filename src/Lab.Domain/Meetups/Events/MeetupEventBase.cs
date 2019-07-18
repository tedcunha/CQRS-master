using Lab.Domain.Core.Events;
using System;

namespace Lab.Domain.Meetups.Events
{
    public abstract class MeetupEventBase : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string ShortDescription { get; protected set; }
        public string LongDescription { get; protected set; }
        public DateTime DateHome { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public bool Free { get; protected set; }
        public decimal MeetupValue { get; protected set; }
        public bool Online { get; protected set; }
        public string CompanyName { get; protected set; }
    }
}
