using kurs_matematyki.Core.DTO;
using kurs_matematyki.Core.Identity;
using kurs_matematyki.Core.Services.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace kurs_matematyki_api.Controllers.Account
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IMailService _mailService;
        private IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager,
            IMailService mailService, IUserService userService, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mailService = mailService;
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> PostRegister(RegisterDTO registerDTO)
        {
            //Validation
            if (ModelState.IsValid == false)
            {
                string errorMessage = string.Join(" | ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e =>
                    e.ErrorMessage));
                return Problem(errorMessage);
            }

            var registerResult = await _userService.RegisterAsync(registerDTO);
                
            if (registerResult.IsSuccess)
            {
                return Ok(registerResult.Message);
            }
            else
            {
                return Problem(registerResult.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> PostLogin(LoginDTO loginDTO)
        {
            //Validation
            if (ModelState.IsValid == false)
            {
                string errorMessage = string.Join(" | ",
                    ModelState.Values.SelectMany(v => v.Errors).Select(e =>
                    e.ErrorMessage));
                return Problem(errorMessage);
            }
            var loginResult = await _userService.LoginAsync(loginDTO);

            if (loginResult.IsSuccess)
            {
                return Ok(loginResult.Message);
            }
            else
            {
                return Problem(loginResult.Message);
            }
        }
    }
}
