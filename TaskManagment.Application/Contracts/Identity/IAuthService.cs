using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.Models.Email;
using TaskManagment.Application.Models.Identity;
using TaskManagment.Application.Responses;

namespace TaskManagment.Application.Contracts.Identity
{
    public interface IAuthService
    {
        public Task<Result<RegistrationResponse>> Register(RegisterModel request);

        public Task<Result<LoginResponse>> Login(LoginModel request);

        public Task<Result<string>> sendConfirmEmailLink(string Email);

        public Task<Result<string>> ConfirmEmail(string token, string email);

        public Task<Result<string>> ForgotPassword(string Email);

        public Task<Result<string>> ResetPassword(ResetPasswordModel resetPasswordModel);

        public Task<bool> DeleteUser(string Email);
    }
}
