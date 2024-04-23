using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurveyBucks.Internal.Application.Services.Contract;
using SurveyBucks.Internal.Infrastructure.Identity.Models;
using SurveyBucks.Internal.Infrastructure.Identity.Models.Request;
using System.Threading.Tasks;

namespace SurveyBucks.Internal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public AccountController(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            return Ok(await _authService.Login(loginRequest));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegistrationRequest registrationRequest)
        {
            return Ok(await _authService.Register(registrationRequest));
        }
    }
}
