using Lab.Domain.Meetups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.Street)
                 .IsRequired()
                 .HasMaxLength(150)
                 .HasColumnType("varchar(150)");

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Neighborhood)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnType("varchar(8)");

            builder.Property(e => e.Complement)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.HasOne(c => c.Meetup)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(c => c.MeetupId)
                .IsRequired(false);

            builder.ToTable("Address");
        }
    }
}
