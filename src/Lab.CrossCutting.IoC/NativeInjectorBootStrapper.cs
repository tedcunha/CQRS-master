using AutoMapper;
using Eventos.IO.Infra.CrossCutting.Identity.Models;
using Eventos.IO.Infra.CrossCutting.Identity.Services;
using Lab.Application.Interfaces;
using Lab.Application.Services;
using Lab.CrossCutting.AspNetFilter;
using Lab.CrossCutting.Bus;
using Lab.Data.Context;
using Lab.Data.Repositories;
using Lab.Data.UoW;
using Lab.Domain.CommandHandlers;
using Lab.Domain.Core.Bus;
using Lab.Domain.Core.Events.Interfaces;
using Lab.Domain.Core.Notifications;
using Lab.Domain.Core.Notifications.Interfaces;
using Lab.Domain.Interfaces;
using Lab.Domain.Meetups.Commands;
using Lab.Domain.Meetups.Events;
using Lab.Domain.Meetups.Interfaces.Repositories;
using Lab.Domain.Organizers.Commands;
using Lab.Domain.Organizers.Events;
using Lab.Domain.Organizers.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lab.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
           
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<RegisterMeetupCommand>, MeetupCommandHandler>();

            services.AddScoped<IHandler<UpdateMeetupCommand>, MeetupCommandHandler>();
            services.AddScoped<IHandler<RemoveMeetupCommand>, MeetupCommandHandler>();
            services.AddScoped<IHandler<UpdateAddressMeetupCommand>, MeetupCommandHandler>();
            services.AddScoped<IHandler<IncludeAddressMeetupCommand>, MeetupCommandHandler>();
            services.AddScoped<IHandler<RegisterOrganizerCommand>, OrganizerCommandHandler>();

            // Domain - Eventos
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<MeetupRegisteredEvent>, MeetupEventHandler>();

            services.AddScoped<IHandler<MeetupUpdatedEvent>, MeetupEventHandler>();
            services.AddScoped<IHandler<MeetupRemovedEvent>, MeetupEventHandler>();
            services.AddScoped<IHandler<AddressMeetupUpdatedEvent>, MeetupEventHandler>();
            services.AddScoped<IHandler<RegisteredMeetingMeetupAddress>, MeetupEventHandler>();
            services.AddScoped<IHandler<OrganizerRegisteredEvent>, OrganizerMeetupHandler>();

            // Infra - Data
            services.AddScoped<IMeetupRepository, MeetupRepository>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LabContext>();

            //// Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

            // Infra - Data EventSourcing
            

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();


            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();










        }
    }
}
