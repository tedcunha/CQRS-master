using AutoMapper;
using Lab.Application.ViewModels;
using Lab.Domain.Meetups;
using Lab.Domain.Organizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Meetup, MeetupViewModel>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Organizer, OrganizerViewModel>();
        }
    }
}
