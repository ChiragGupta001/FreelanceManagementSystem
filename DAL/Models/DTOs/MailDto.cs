using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs
{
    public class MailDto
    {
        public string To { get; set; }
        public string From { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
