using Lab.Domain.Meetups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Data.Mappings
{
    public class MeetupMapping : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.Property(e => e.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.ShortDescription)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.LongDescription)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.CompanyName)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.Tags);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Meetup");

            builder.HasOne(e => e.Organizer)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizerId);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Meetup)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);
        }
    }
}
