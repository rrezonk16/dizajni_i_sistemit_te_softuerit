using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using dizajni_i_sistemit_softuerik.Repositories;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        public AuthController(IUserService userService, ITokenService tokenService, IUserRepository userRepository, IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;

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


      

        [HttpGet("me")]
        public async Task<IActionResult> GetUserFromToken()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                if (jwtToken == null)
                    return Unauthorized(new { message = "Invalid token" });

                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                    return Unauthorized(new { message = "Invalid token claims" });

                var userId = int.Parse(userIdClaim.Value);

                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null)
                    return NotFound(new { message = "User not found" });

                return Ok(new
                {
                    user.Id,
                    user.Name,
                    user.Surname,
                    user.Email,
                    user.PhoneNumber,
                    user.Address
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
