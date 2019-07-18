using Lab.Domain.Core.Notifications.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {  
        public List<DomainNotification> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public void Handle(DomainNotification message)
        {
            throw new NotImplementedException();
        }

        public bool HasNotifications()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
