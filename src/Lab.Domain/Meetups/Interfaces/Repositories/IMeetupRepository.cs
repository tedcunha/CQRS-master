using Lab.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Lab.Domain.Meetups.Interfaces.Repositories
{
    public interface IMeetupRepository : IRepository<Meetup>
    {
        IEnumerable<Meetup> GetMeetupOrganizer(Guid organizerId);
        Address GetAddressById(Guid id);
        void AddAddress(Address address);
        void UpdateAddress(Address address);
        IEnumerable<Category> GetCategory();
    }
}
