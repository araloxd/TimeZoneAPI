using Application.Services;
using Core.DTOs;
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


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = await _userService.RegisterUserAsync(userDto.Username, userDto.Password, userDto.TimeZone);
            return CreatedAtAction(nameof(UserDTO), new { Username = userId });
        }
    }
}