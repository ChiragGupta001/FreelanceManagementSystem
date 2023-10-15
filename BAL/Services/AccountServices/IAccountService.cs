using DAL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.AccountServices
{
    public interface IAccountService
    {
        Task<Token> IsLogin(LoginDto login);
        //Task<string> IsLogin(LoginDto login);
        Task<string> RegisterUser(SignUpDto signUp);
    }
}
