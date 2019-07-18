using Lab.Domain.Core.Models;
using Lab.Domain.Organizers;
using System;
using System.Collections.Generic;

namespace Lab.Domain.Meetups
{
    public class Meetup : Entity<Meetup>
    {
        public Meetup(
                      string name,
                      string shortDescription,
                      string longDescription,
                      DateTime dateHome,
                      DateTime endDate,
                      bool free,
                      decimal meetupValue,
                      bool online,
                      string companyName
                     )
        {
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            DateHome = dateHome;
            EndDate = endDate;
            Free = free;
            MeetupValue = meetupValue;
            Online = online;
            CompanyName = companyName;
        }
        private Meetup() { }
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }
        public DateTime DateHome { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Free { get; private set; }
        public decimal MeetupValue { get; private set; }
        public bool Online { get; private set; }
        public string CompanyName { get; private set; }
        public bool Excluded { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Guid? CategoryId { get; private set; }
        public Guid? AddressId { get; private set; }
        public Guid OrganizerId { get; private set; }
        // EF propriedades de navegacao
        public virtual Category Category { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual Organizer Organizer { get; private set; }
        public void AtribuirEndereco(Address address)
        {
            if (!address.IsValid()) return;
            Address = address;
        }
        public void AtribuirCategoria(Category category)
        {
            if (!category.IsValid()) return;
            Category = category;
        }
      
        public void RemoveMeetup()
        {
            // TODO: Deve validar alguma regra?
            Excluded = true;
        }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
        //Fatory
        public static class MeetupFactory
        {
            public static Meetup NewMeetupComplet(
                Guid id, 
                string name, 
                string shortDescription, 
                string longDescription,
                DateTime dateHome, 
                DateTime endDate, 
                bool free,
                decimal meetupValue, 
                bool online, 
                string companyName,
                 Guid? organizerId, 
                 Address address, 
                 Guid categoryId)
            {
                var meetup = new Meetup()
                {
                    Id = id,
                    Name = name,
                    ShortDescription = shortDescription,
                    LongDescription = longDescription,
                    DateHome = dateHome,
                    EndDate = endDate,
                    Free = free,
                    MeetupValue = meetupValue,
                    Online = online,
                    CompanyName = companyName,
                    Address = address,
                    CategoryId = categoryId
                };
                if (organizerId.HasValue)
                    meetup.OrganizerId = organizerId.Value;
                if (online)
                    meetup.Address = null;
                return meetup;
            }
        }
    }
}
