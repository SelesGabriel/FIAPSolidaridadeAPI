using Microsoft.AspNetCore.Mvc;
using FIAPSolidaridadeAPI.DTOs;
using FIAPSolidaridadeAPI.Services;

namespace FIAPSolidaridadeAPI.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("area/{area}")]
        public async Task<IActionResult> GetUsersByArea(string area)
        {
            var user = await _userService.GetUsersByAreaAsync(area);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetUsersByRegion(string region)
        {
            var user = await _userService.GetUsersByRegionAsync(region);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            var createdUser = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isDeleted = await _userService.DeleteUserAsync(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }
    }
}
