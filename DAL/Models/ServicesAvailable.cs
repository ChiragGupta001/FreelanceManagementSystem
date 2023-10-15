using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ServicesAvailable
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double price { get ; set; }  
        public string image { get;set; }

        public string serviceTypeId { get; set; }
        public ServiceType serviceType { get; set; }

        public string userId { get; set; }
        public User user { get; set; }
    }
}
