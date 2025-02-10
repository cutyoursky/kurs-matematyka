using kurs_matematyki.Core.DTO;
using kurs_matematyki.Core.Entities;
using kurs_matematyki.Core.Identity;
using kurs_matematyki.Core.Services.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public Task<UserManagerResponse> ForgetPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }




        public Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            throw new NotImplementedException();
        }
    }
}
