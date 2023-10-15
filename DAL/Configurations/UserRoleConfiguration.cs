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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "4d913ae6-b161-446d-9759-2145d277c1d3",
                    RoleId = "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0"
                },
                 new IdentityUserRole<string>()
                 {
                     UserId = "4e0d71e3-7aca-4afa-b41c-ad99c9fb5ca7",
                     RoleId = "94d5a42a-076a-440d-b57c-d2fca8896085"
                 });
        }
    }
}
