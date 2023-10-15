using DAL.Models;
using DAL.Models.DTOs;
using DAL.Repositories.GenericRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<IdentityUserRole<string>> _userRoleRepository;
        public AccountService(UserManager<User> userManager,
                              IConfiguration configuration,
                              IGenericRepository<User> userRepository,
                              IGenericRepository<IdentityUserRole<string>> userRoleRepository) 
        {
            _userManager = userManager;
            _configuration = configuration;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<Token> IsLogin(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user != null)
            {
                var isExist = await _userManager.CheckPasswordAsync(user, login.Password);

                if (isExist)
                {
                    var token = await GetToken(user);
                    var authToken = new Token { token = token };
                    return authToken;
                }
            }

            return null;
        }

        //public async Task<string> IsLogin(LoginDto login)
        //{
        //    var user = await _userManager.FindByEmailAsync(login.Email);

        //    if (user != null)
        //    {
        //        var isExist = await _userManager.CheckPasswordAsync(user, login.Password);

        //        if (isExist)
        //        {
        //            var token = await GetToken(user);
        //            //var authToken = new Token { token = token };
        //            return token;
        //        }
        //    }

        //    return null;
        //}
        //}


        public async Task<string> GetToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim("UserName", user.UserName),
                new Claim("Id", user.Id),
                new Claim("Email", user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));
            var expires = DateTime.Now.AddMinutes(120);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<string> RegisterUser(SignUpDto signUp)
        {
            User user = new User();
            IdentityUserRole<string> role = new IdentityUserRole<string>();
            var userDto = await _userManager.FindByEmailAsync(signUp.Email);
            if(userDto == null)
            {
                user.Id = Guid.NewGuid().ToString();
                user.Name = signUp.Name;
                user.UserName = signUp.Name;
                user.Email = signUp.Email;
                user.NormalizedEmail = signUp.Email.ToUpper();
                user.EmailConfirmed = true;
                user.PhoneNumber = signUp.PhoneNumber;
                user.PasswordHash = new PasswordHasher<User>().HashPassword(null, signUp.Password);
                
                if(signUp.Role == "Customer")
                {
                    role.UserId = user.Id;
                    role.RoleId = "db45eba7-bfea-4bb7-a6a8-45ae1a59e9a0";
                }else if(signUp.Role == "ServiceProvider")
                {
                    role.UserId = user.Id;
                    role.RoleId = "94d5a42a-076a-440d-b57c-d2fca8896085";
                }

                _userRepository.Insert(user);
                _userRoleRepository.Insert(role);
                _userRepository.Save();
                return "User Register Successfully";
            }
            return "User Already Exist";

        }
    }
}
