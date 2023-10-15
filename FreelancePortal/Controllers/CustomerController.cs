using BAL.Services.EmailService;
using BAL.Services.PaginatedService;
using BAL.Services.ProviderServices;
using DAL.Models;
using DAL.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger;
using System;


namespace FreelancePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IProviderService _provider;
        private readonly IEmailSender _emailSender;
        private readonly IPaginatedService<ServicesAvailable> _page;

        public CustomerController(IProviderService Provider,
                                  IEmailSender emailSender,
                                  IPaginatedService<ServicesAvailable> page)
        {
            _provider = Provider;
            _page = page;
            _emailSender = emailSender;
        }

        [HttpGet("GetAllServices")]
        [Authorize(Roles = "Customer")]
        public ActionResult GetAllServices(int pageIndex, int pageSize, string? keyword)
        {
            var list = _provider.GetAll();
            if (list != null)
            {
                var PageList = _page.PageList(list, pageIndex, pageSize, keyword);
                return Ok(PageList);
            }
            return BadRequest("Something Went Wrong");
        }


        [HttpPost("GetSearch")]
        [Authorize(Roles = "Customer")]
        public ActionResult GetSearch(string search)
        {
            var list = _provider.GetAll();
            if (list != null)
            {
                if (search == "")
                {
                    return Ok(list);
                }
                else if (search == null)
                {
                    return Ok(list);
                }
                else
                {
                    var searchlist = list.Where(m => m.Title.ToLower().Contains(search.ToLower())).ToList();
                    return Ok(searchlist);
                }
            }
            return BadRequest("Something Went Wrong");
        }


        [HttpPost("SendMail")]
        [AllowAnonymous]
        public async Task<ActionResult> SendMail(MailDto mail)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            var message = new Message(new string[] { mail.To }, mail.subject, mail.body, files);
            await _emailSender.SendEmailAsync(message);
            return Ok("Email Send Succesfully");
        }


        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPassword)
        {
            var user = await _emailSender.UserByEmail(forgotPassword.Email);
            if (user != null)
            {
                var token = await _emailSender.Token(user);

                var param = new Dictionary<string, string?>
                {
                    {"token", token },
                    {"email", forgotPassword.Email }
                };
                var callback = QueryHelpers.AddQueryString(forgotPassword.ClientURI, param);

                //var scheme = "http";
                //var yourDomain = "http://localhost:4200";
                //var controller = "";
                //var action = "";
                //var callback = $"{scheme}://{yourDomain}/{controller}/{action}?token={token}&email={user.Email}";
                //var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
                await _emailSender.SendEmailAsync(message);
                return Ok();
            }
            return BadRequest("Something Went Wrong");
        }

        //
        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPassword)
        {
            var user = await _emailSender.UserByEmail(resetPassword.Email);
            if (user != null)
            {
                var res = await _emailSender.ResetPassword(resetPassword, user);
                return Ok(res);
            }
            return BadRequest("user Don't Exist");
        }


        // get email of service provider by id of service
        [HttpPost("GetEmail")]
        [AllowAnonymous]
        public ActionResult getEmail(ServiceDto service)
        {
            var res = _provider.GetServiceById(service.Id);
            if(res != null)
            {
                //return Ok(res.user.Email);
                var user = _provider.GetUser(res.userId);
                return Ok(user.Email);
            }
            return BadRequest("something Went Wrong");

        }
    }
}
