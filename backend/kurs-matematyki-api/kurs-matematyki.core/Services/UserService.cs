using kurs_matematyki.Core.DTO;
using kurs_matematyki.Core.Entities;
using kurs_matematyki.Core.Identity;
using kurs_matematyki.Core.Services.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_matematyki.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mailService = mailService;
        }

        public async Task<UserManagerResponse> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                UserName = registerDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return new UserManagerResponse
                {
                    Message = "User created successfully!",
                    IsSuccess = true
                };
            }
            else
            {
                string errors = string.Join(" | ", result.Errors.Select(e => e.Description));
                return new UserManagerResponse
                {
                    Message = errors,
                };
            }


        }

        public async Task<UserManagerResponse> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with that email address",
                    IsSuccess = false
                };
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
                if (result.Succeeded)
                {
                    return new UserManagerResponse
                    {
                        Message = "User logged in successfully!",
                        IsSuccess = true
                    };
                }
                else
                {
                    return new UserManagerResponse
                    {
                        Message = "Invalid password",
                        IsSuccess = false
                    };
                }
            }
        }

        public async Task<UserManagerResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return new UserManagerResponse()
                {
                    Message = "There is no user with that email address",
                    IsSuccess = false
                };
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(code);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            var link = $"{_configuration["AppUrl"]}/change-password?email={user.UserName}&activationToken={validToken}";

            await _mailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{link}'>Click here</a></p>");

            return new UserManagerResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }




        public Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            throw new NotImplementedException();
        }
    }
}
