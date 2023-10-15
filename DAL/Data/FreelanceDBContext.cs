using DAL.Configurations;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class FreelanceDBContext : IdentityDbContext<User>
    {
        public FreelanceDBContext(DbContextOptions<FreelanceDBContext> options): base(options)
        {
        }
        public FreelanceDBContext(): base() { }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.Entity<ServiceType>().HasData(
                new ServiceType()
                {
                    Id = "6fe8755b-080a-40e0-9347-ace110fcef60",
                    Service = "Web Development"
                },
                new ServiceType()
                {
                    Id = "b9e3dba2-7d9a-4af8-8f64-0be6b4a868df",
                    Service = "Graphic Designing"
                },
                new ServiceType()
                {
                    Id = "743e7821-5b25-450c-99f7-3c7bbb3e60c7",
                    Service = "Carpenter"
                });
            builder.Entity<ServicesAvailable>().HasKey(c => c.Id);
            builder.Entity<ServicesAvailable>().HasOne(c => c.user).WithMany().HasForeignKey(cb => cb.userId);
            builder.Entity<ServiceType>().HasKey(c => c.Id);
            builder.Entity<ServicesAvailable>().HasOne(c => c.serviceType).WithMany().HasForeignKey(cb => cb.serviceTypeId);

        }


        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServicesAvailable> ServicesAvailable { get; set; }
    }
}
