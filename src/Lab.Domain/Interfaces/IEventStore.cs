using Lab.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Domain.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}
