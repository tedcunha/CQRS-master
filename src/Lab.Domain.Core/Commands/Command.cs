using Lab.Domain.Core.Events;
using System;

namespace Lab.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
