using Learn_Net.DTOs;
using Learn_Net.Services;
using Learn_Net.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Learn_Net.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwt;

        public AuthController(IUserService userService, IJwtService jwt)
        {
            _userService = userService;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var exists = await _userService.GetByEmailAsync(req.Email);
            if (exists != null) return BadRequest(new { message = "Email already used" });

            var user = await _userService.RegisterAsync(req.FullName, req.Email, req.Password);
            var resp = new UserResponse { Id = user.Id, FullName = user.FullName, Email = user.Email };
            return CreatedAtAction(null, resp);
        }
    }
}
