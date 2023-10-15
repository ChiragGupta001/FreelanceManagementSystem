using DAL.Models;
using DAL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.EmailService
{

    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
        Task<string> Token(User user);
        Task<User> UserByEmail(string Email);
        Task<string> ResetPassword(ResetPasswordDto resetPassword, User user);
    }
    
}
