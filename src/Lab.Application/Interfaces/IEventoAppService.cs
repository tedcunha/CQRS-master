using Lab.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Lab.Application.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        void Register(MeetupViewModel meetupViewModel);
        IEnumerable<MeetupViewModel> GetAll();
        IEnumerable<MeetupViewModel> GetMeetupByOrganizer(Guid organizerId);
        MeetupViewModel GetById(Guid id);
        void Update(MeetupViewModel meetupViewModel);
        void Remove(Guid id);

        void AddAddress(AddressViewModel addressViewModel);
        void UpdateAddress(AddressViewModel addressViewModel);
        AddressViewModel GetAddressById(Guid id);
    }
}
