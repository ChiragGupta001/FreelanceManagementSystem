using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs
{
    public class ServiceCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double price { get; set; }
        public IFormFile image { get; set; }
        public string serviceTypeId { get; set; }
        public string userId { get; set; }
    }
}
