using BAL.Services.AccountServices;
using DAL.Models.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreelancePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _account; 
        public AccountController(IAccountService account) 
        {
            _account = account;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto model)
        {
            var IsLog = await _account.IsLogin(model);
            if(IsLog != null)
            {
                return Ok(IsLog);
            }
            return BadRequest("User Don't Exist");
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(SignUpDto model)
        {
            var IsRegister = await _account.RegisterUser(model);
            if(IsRegister == "User Register Successfully")
            {
                return Ok("User Register successfully");
            }
            return BadRequest("User Already Exist");
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

    }
}
