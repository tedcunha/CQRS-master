using Lab.Domain.Core.Commands;
using System;

namespace Lab.Domain.Meetups.Commands
{
    public class UpdateAddressMeetupCommand : Command
    {
        public UpdateAddressMeetupCommand(Guid id, string street, string number, string complement, string neighborhood, string cEP, string city, string state, Guid? meetupId)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            CEP = cEP;
            City = city;
            State = state;
            MeetupId = meetupId;
        }
        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string CEP { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid? MeetupId { get; private set; }
    }
}

