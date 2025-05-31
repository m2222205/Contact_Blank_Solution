using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(80);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Address).IsRequired().HasMaxLength(100);

            builder.Property(c => c.City).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Region).IsRequired(false).HasMaxLength(100);

        }
    }
}
