using DAL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.PaginatedService
{
    public class PaginatedService<T> : IPaginatedService<T> where T : class
    {
        public PageListDto<T> PageList(List<T> list , int pageIndex, int pagesize, string? keyword)
        {
           
            if(pageIndex.Equals(0) || pageIndex == null){
                pageIndex = 1;
            }
            if(pagesize.Equals(0) || pagesize == null){
                pagesize = 10;
            }
            var query = list;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = LikeSearch<T>(list, "Title", keyword);
            }

            int totalItems = list.Count;
            var totalPages = (int)Math.Ceiling(list.Count/(double)pagesize);
            if(totalPages > 0 && pageIndex <= totalPages)
            {
                List<T> PaginatedList = query.Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
                return new PageListDto<T>
                {
                    list = PaginatedList,
                    PageCount = totalPages,
                    PageIndex = pageIndex,
                    PageSize = pagesize,
                    totalCount = totalItems
                };
            }
            return null;
        }

        public static List<T> LikeSearch<T>(List<T> data, string key, string searchString)
        {
            var property = typeof(T).GetProperty(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);

            if (property == null)
                throw new ArgumentException($"'{typeof(T).Name}' does not implement a public get property named '{key}'.");

            return data.Where(d => ((string)property.GetValue(d)).Contains(searchString)).ToList();
        }
    }
}