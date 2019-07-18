using System;
namespace Lab.Domain.Meetups.Commands
{
    public class RegisterMeetupCommand : MeetupCommandBase
    {       
        public RegisterMeetupCommand(string name, 
                                        string shortDescription, 
                                        string longDescription, 
                                        DateTime dateHome, 
                                        DateTime endDate, 
                                        bool free, 
                                        decimal meetupValue, 
                                        bool online, 
                                        string companyName, 
                                        Guid organizerId, 
                                        Guid categoryId,
                                        IncludeAddressMeetupCommand address
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
            OrganizerId = organizerId;
            CategoryId = categoryId;
            Address = address;
        }
        public IncludeAddressMeetupCommand Address { get; private set; }
    }
}
