using Application.Services;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userId = await _userService.RegisterUserAsync(userDto.Username, userDto.Password, userDto.TimeZone);
                return CreatedAtAction(nameof(UserDTO), new { Username = userId });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _userService.AuthenticateUserAsync(loginDto.Username, loginDto.Password);
            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid username or password." });
            }

            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserProfile(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound(new { Message = "User not found." });

            return Ok(user);
        }
    }
}