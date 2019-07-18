using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Domain.Meetups.Events
{
    public class MeetupUpdatedEvent : MeetupEventBase
    {
        public MeetupUpdatedEvent(Guid id, string name,
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
            AggregateId = id;
        }
    }
}
