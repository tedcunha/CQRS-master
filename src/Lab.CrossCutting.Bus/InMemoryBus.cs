using Lab.Domain.Core.Bus;
using Lab.Domain.Core.Commands;
using Lab.Domain.Core.Events;
using Lab.Domain.Core.Events.Interfaces;
using Lab.Domain.Core.Notifications.Interfaces;
using System;

namespace Lab.CrossCutting.Bus
{
    public sealed class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }
        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }
        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));
            ((IHandler<T>)obj).Handle(message);
        }
    }
}
