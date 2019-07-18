using System;

namespace Lab.Domain.Meetups.Events
{
    public class MeetupRegisteredEvent : MeetupEventBase
    {
        public MeetupRegisteredEvent(Guid id, string name,                                        
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
