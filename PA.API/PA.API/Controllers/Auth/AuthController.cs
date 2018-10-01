using System.Threading.Tasks;
using API.DataObjects.DTOs;
using API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PA.API.ViewModels;

namespace PA.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]        
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            var result = _authService.ValidateUser(new LoginDto() { Username = loginVM.Username, Password = loginVM.Password });
            if (!string.IsNullOrEmpty(result))
            {
                return Ok(new ApiResult (true, result, "valid user." ));
            }
            return Ok(new ApiResult(false, result, "authentication failed."));
        }
    }
}