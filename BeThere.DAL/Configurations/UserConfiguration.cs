using BeThere.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Salt).IsRequired();

            builder.Property(p => p.Password).IsRequired();

            builder.Property(p => p.Email)
               .HasMaxLength(150).IsRequired();

            builder.Property(p => p.Username)
             .HasMaxLength(150).IsRequired();

            builder.Property(p => p.Role)
                .HasMaxLength(150)
             .IsRequired();

        }
    }
}
