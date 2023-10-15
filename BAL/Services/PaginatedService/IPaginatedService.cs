using DAL.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.PaginatedService
{
    public interface IPaginatedService<T> where T : class
    {
        PageListDto<T> PageList(List<T> list, int pageIndex, int pagesize, string? keyword);
    }
}
