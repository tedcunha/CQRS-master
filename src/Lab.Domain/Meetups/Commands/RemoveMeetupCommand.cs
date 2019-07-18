using System;

namespace Lab.Domain.Meetups.Commands
{
    public class RemoveMeetupCommand : MeetupCommandBase
    {
        public RemoveMeetupCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
