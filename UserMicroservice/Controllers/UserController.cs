using Microsoft.AspNetCore.Mvc;
using UserMicroservice.ServiceLayer;
using UserMicroservice.Dto;
using UserMicroservice.SecurityServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AuthService _authService;
        public UserController(IUserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Login(request.EmployeeId, request.Password);
            if (token != null)
            {
                return Ok(new { token = token });
            }

            return Unauthorized("Invalid username or password.");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<NewUserDto>> CreateUser([FromBody] NewUserDto newUserDto)
        {
            var createdUserDto = await _userService.CreateUserAsync(newUserDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUserDto.Id }, createdUserDto);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/CheckPasswordChange")]
        [Authorize]
        public async Task<IActionResult> CheckPasswordChange(int id)
        {
            var shouldChangePassword = await _userService.CheckIfPasswordShouldChangeAsync(id);
            if (shouldChangePassword)
            {
                return Ok(new { message = "You should change your password." });
            }
            else
            {
                return Ok(new { message = "Your password is still valid." });
            }
        }

    }
}
