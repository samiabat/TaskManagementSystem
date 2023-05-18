using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagemnt.Domain;

namespace TaskManagement.Persistence.Configerations.Entities
{
    public class UserConfigeration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 2,
                    Email = "samuel@gmail.com",
                    Password = "Samuel",
                    FullName = "Samuel Abatneh",

                }
            );

            builder.Property(q => q.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(q => q.Password)
                .IsRequired();
            builder.Property(q=>q.FullName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
