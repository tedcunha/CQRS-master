using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Domain.Meetups.Commands
{
    public class UpdateMeetupCommand : MeetupCommandBase
    {
        public UpdateMeetupCommand(
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
                                   Guid organizerId,
                                   Guid categoryId
                                  )
        {
            Id = id;
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
        }
    }
}
