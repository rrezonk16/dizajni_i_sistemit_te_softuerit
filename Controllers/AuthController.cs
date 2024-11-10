using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.DTOs;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService; // Service for generating JWT tokens.

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _userService.RegisterAsync(request.Name, request.Surname, request.Email, request.Password, request.PhoneNumber, request.Address);
                var token = _tokenService.GenerateToken(user); // Generate JWT token here
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userService.LoginAsync(request.Email, request.Password);
                var token = _tokenService.GenerateToken(user); // Generate JWT token here
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
