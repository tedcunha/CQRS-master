using Lab.Domain.Core.Events;
using Lab.Domain.Core.Events.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab.Domain.Core.Notifications.Interfaces
{
    public interface IDomainNotificationHandler<T> : IDisposable, IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
