using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs
{
    public class PageListDto<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public List<T> list {  get; set; }
        public int totalCount { get; set; }
    }
}
    