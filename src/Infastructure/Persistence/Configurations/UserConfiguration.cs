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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(50);

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(u => u.PasswordHash).IsRequired();

            builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
             .IsRequired();

            builder.HasMany(u => u.Contacts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserID);

           
            builder.HasMany(u => u.RefreshTokens)
                .WithOne(c => c.User)
                .HasForeignKey(r => r.UserId);

        }
    }
}
