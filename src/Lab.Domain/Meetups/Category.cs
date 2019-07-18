using Lab.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Lab.Domain.Meetups
{
    public class Category : Entity<Category>
    {
        public Category(Guid id)
        {
            Id = id;
        }
        public string Name { get; private set; }       
        public virtual ICollection<Meetup> Meetup { get; set; }      
        protected Category() { }
        public override bool IsValid()
        {
            return true;
        }
    }
}
