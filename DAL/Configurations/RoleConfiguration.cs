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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Id = "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",

                },
                new IdentityRole()
                {
                    Id = "94d5a42a-076a-440d-b57c-d2fca8896085",
                    Name = "ServiceProvider",
                    NormalizedName = "SERVICEPROVIDER",
                });
        }
    }
}
    