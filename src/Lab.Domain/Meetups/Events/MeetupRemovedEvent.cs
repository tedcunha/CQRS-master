using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Domain.Meetups.Events
{
    public class MeetupRemovedEvent : MeetupEventBase
    {
        public MeetupRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
