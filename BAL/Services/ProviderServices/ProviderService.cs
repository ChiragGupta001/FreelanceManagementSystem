using DAL.Models;
using DAL.Models.DTOs;
using DAL.Repositories.GenericRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.ProviderServices
{
    public class ProviderService : IProviderService
    {
        private readonly IGenericRepository<ServicesAvailable> _serviceAvailable;
        private readonly IGenericRepository<ServiceType> _serviceType;
        private readonly IGenericRepository<User> _user;
        private IHostingEnvironment _host;

        public ProviderService(IGenericRepository<ServicesAvailable> serviceAvailable,
                               IGenericRepository<ServiceType> serviceType,
                               IHostingEnvironment host,
                               IGenericRepository<User> user)
        {
            _serviceAvailable = serviceAvailable;
            _serviceType = serviceType;
            _user = user;
            _host = host;
        }   

        public List<ServicesAvailable> GetAll()
        {
            return _serviceAvailable.GetAll().ToList();
        }

        public async Task<string> CreateServices(ServiceCreateDto service)
        {
            var newService = new ServicesAvailable();
            if(service != null)
            {
                newService.Id = Guid.NewGuid();
                newService.Title = service.Title;
                newService.Description = service.Description;
                newService.price = service.price;
                newService.image = await UploadedFile(service.image);
                newService.userId = service.userId;
                newService.serviceTypeId = service.serviceTypeId;
                _serviceAvailable.Insert(newService);
                _serviceAvailable.Save();
                return "Service Created Successfully";
            }
            return "Service Not Created";
        }

        public string DeleteServices(Guid id)
        {
            var service = _serviceAvailable.GetById(id);
            if (service != null)
            {
                _serviceAvailable.Delete(id);
                _serviceAvailable.Save();
                return "Service Deleted";
            }
            return "Service not Exist";
        }

        public async Task<string> EditServices(EditServiceDto edit)
        {
            var service = _serviceAvailable.GetById(edit.Id);
            if (service != null)
            {
                service.Title = edit.Title;
                service.Description = edit.Description;
                service.price = (double)edit.price;
                service.image = await UploadedFile(edit.image);
                service.serviceTypeId = edit.serviceTypeId;
                service.userId = edit.userId;

                _serviceAvailable.Update(service);
                _serviceAvailable.Save();
                return "Edit Succesfull";
            }
            return "Something Went Wrong";
        }


        public async Task<string> UploadedFile(IFormFile fileUpload)
        {
            try
            {
                if (fileUpload.Length > 0)
                {
                    string path = Path.Combine(_host.WebRootPath + "\\uploads\\");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);

                    }
                    string filePath = Path.Combine(path, fileUpload.FileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileUpload.CopyToAsync(fileStream);
                        return "https://localhost:7199/uploads/" + fileUpload.FileName;
                    };
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ServicesAvailable GetServiceById(Guid Id)
        {
            return _serviceAvailable.GetById(Id);
        }

        public List<ServiceType> GetAllTypes()
        {
            return _serviceType.GetAll().ToList();
        }

        public User GetUser(string Id)
        {
            return _user.GetById(Id);
        }
    }
}
