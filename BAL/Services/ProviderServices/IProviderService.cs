using DAL.Models;
using DAL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.ProviderServices
{
    public interface IProviderService
    {
        List<ServicesAvailable> GetAll();
        Task<string> CreateServices(ServiceCreateDto service);
        string DeleteServices(Guid id);
        Task<string> EditServices(EditServiceDto edit);
        List<ServiceType> GetAllTypes();
        ServicesAvailable GetServiceById(Guid Id);
        User GetUser(string Id);
    }
}
