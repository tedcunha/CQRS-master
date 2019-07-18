using Lab.Domain.Core.Models;
using System;

namespace Lab.Domain.Meetups
{
    public class Address : Entity<Address>
    {
        public Address(Guid i, string street, string number, string complement, string neighborhood, string cEP, string city, string state, Guid? meetupId)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            CEP = cEP;
            City = city;
            State = state;
            MeetupId = meetupId;
        }
        protected Address()
        {
        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string CEP { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid? MeetupId { get; private set; }        
        public virtual Meetup Meetup { get; private set; }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
