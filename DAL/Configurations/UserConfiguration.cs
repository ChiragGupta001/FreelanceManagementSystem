using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User()
                {
                    Id = "4d913ae6-b161-446d-9759-2145d277c1d3",
                    Name = "Customer",
                    UserName = "Customer",
                    NormalizedUserName = "CUSTOMER",
                    Email = "customer@gmail.com",
                    NormalizedEmail = "CUSTOMER@GMAIL.COM",
                    PhoneNumber = "7418529635",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "Customer@123"),
                },
                new User()
                {
                    Id = "4e0d71e3-7aca-4afa-b41c-ad99c9fb5ca7",
                    Name = "Service Provider",
                    UserName = "ServiceProvider",
                    NormalizedUserName = "SERVICEPROVIDER",
                    Email = "serviceprovider@gmail.com",
                    NormalizedEmail = "SERVICEPROVIDER@GMAIL.COM",
                    PhoneNumber = "7418529965",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, "Service@123"),
                });
        }
    }
}
