using Lab.Data.Context;
using Lab.Domain.Meetups;
using Lab.Domain.Meetups.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Data.Repositories
{
    public class MeetupRepository : Repository<Meetup>, IMeetupRepository
    {
        public MeetupRepository(LabContext labContext) : base(labContext)
        {
        }
        public void AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Address GetAddressById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meetup> GetMeetupOrganizer(Guid organizerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
