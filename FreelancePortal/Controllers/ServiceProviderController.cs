using BAL.Services.PaginatedService;
using BAL.Services.ProviderServices;
using DAL.Models;
using DAL.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProviderController : ControllerBase
    {

        private readonly IProviderService _provider;
        private readonly IPaginatedService<ServicesAvailable> _page;
        public ServiceProviderController(IProviderService Provider, IPaginatedService<ServicesAvailable> page)
        {
            _provider = Provider;
            _page = page;
        }


        [HttpGet("GetAllServices")]
        [Authorize(Roles = "ServiceProvider,Customer")]
        public ActionResult GetAllServices(int pageIndex, int pageSize, string? keyword)
        {
            var list = _provider.GetAll();
            if (list != null)
            {
                var PageList = _page.PageList(list, pageIndex, pageSize,keyword);
                return Ok(PageList);
            }
            return BadRequest("Something Went Wrong");
        }

        [HttpPost("GetAllService")]
        [Authorize(Roles = "ServiceProvider,Customer")]
        public ActionResult GetAllService(int pageIndex , int pageSize , string? keyword)
        {
            var list = _provider.GetAll();
            if (list != null)
            {
                var resp = _page.PageList(list,pageIndex,pageSize,keyword);
                if (resp != null)
                {
                    return Ok(resp);
                }
                return BadRequest("page is empty");
            }
            return BadRequest("Something went Wrong");
        }

        [HttpPost("CreateService")]
        [Authorize(Roles = "ServiceProvider")]
        public async Task<ActionResult> CreateService([FromForm] ServiceCreateDto service)
        {
            var isCreated = await _provider.CreateServices(service);
            if(isCreated == "Service Created Successfully")
            {
                return Ok("Service Created Successfully");
            }
            return BadRequest("Something went Wrong");
        }

        [HttpPost("DeleteService")]
        [Authorize(Roles = "ServiceProvider")]
        public ActionResult DeleteService(Guid id)
        {
            var isDeleted = _provider.DeleteServices(id);
            if(isDeleted == "Service Deleted")
            {
                return Ok("Service Deleted Successfully");
            }
            return BadRequest("Something Went Wrong");
        }

        [HttpPost("EditService")]
        [Authorize(Roles = "ServiceProvider")]
        public async Task<ActionResult> EditService([FromForm] EditServiceDto service)
        {
            var isEdit = await _provider.EditServices(service);
            if(isEdit == "Edit Succesfull")
            {
                return Ok("Edit Successfull");
            }
            return BadRequest("Something Went Wrong");
        }

        [HttpGet("GetServiceType")]
        [AllowAnonymous]
        public ActionResult GetServiceType()
        {
            var list = _provider.GetAllTypes().ToList();
            if(list != null)
            {
                return Ok(list);
            }
            return BadRequest("Something went wrong");
        }

        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        public ActionResult GetById(Guid id)
        {
            var resp = _provider.GetServiceById(id);
            if (resp != null)
            {
                return Ok(resp);
            }
            return NotFound("Something went wrong");
        }

    }
}