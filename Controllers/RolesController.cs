using dizajni_i_sistemit_softuerik.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ITokenService _tokenService;

        public RolesController(IRoleService roleService, ITokenService tokenService)
        {
            _roleService = roleService;
            _tokenService = tokenService;
        }

        [HttpGet("get-role")]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            var userId = _tokenService.GetUserIdFromToken(Request.Headers["Authorization"]);
            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            var role = await _roleService.GetUserRoleAsync(userId.Value);
            return Ok(new { Role = role });
        }
    }
}
