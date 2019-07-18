using AutoMapper;
using Lab.Application.ViewModels;
using Lab.Domain.Meetups;
using Lab.Domain.Meetups.Commands;
using Lab.Domain.Organizers;
using Lab.Domain.Organizers.Commands;
using System;

namespace Lab.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
           
            CreateMap<MeetupViewModel, RegisterMeetupCommand>()
               .ConstructUsing(c => new RegisterMeetupCommand(c.Name, c.ShortDescription, c.LongDescription, c.DateHome, c.EndDate, c.Free, c.MeetupValue, c.Online, c.CompanyName, c.OrganizerId, c.CategoryId,
                   new IncludeAddressMeetupCommand(c.Address.Id, c.Address.Street, c.Address.Number, c.Address.Complement, c.Address.Neighborhood, c.Address.CEP, c.Address.City, c.Address.State, c.Id)));

            CreateMap<AddressViewModel, IncludeAddressMeetupCommand>()
                .ConstructUsing(c => new IncludeAddressMeetupCommand(Guid.NewGuid(), c.Street, c.Number, c.Complement, c.Neighborhood, c.CEP, c.City, c.State, c.MeetupId));

            CreateMap<AddressViewModel, UpdateAddressMeetupCommand>()
                .ConstructUsing(c => new UpdateAddressMeetupCommand(Guid.NewGuid(), c.Street, c.Number, c.Complement, c.Neighborhood, c.CEP, c.City, c.State, c.MeetupId));

            CreateMap<MeetupViewModel, UpdateMeetupCommand>()
                .ConstructUsing(c => new UpdateMeetupCommand(c.Id, c.Name, c.ShortDescription, c.LongDescription, c.DateHome, c.EndDate, c.Free, c.MeetupValue, c.Online, c.CompanyName, c.OrganizerId, c.CategoryId));

            CreateMap<MeetupViewModel, RemoveMeetupCommand>()
                .ConstructUsing(c => new RemoveMeetupCommand(c.Id));

            // Organizador
            CreateMap<OrganizerViewModel, RegisterOrganizerCommand>()
                .ConstructUsing(c => new RegisterOrganizerCommand(c.Id, c.Name, c.Document, c.Email));
        }
    }
}
