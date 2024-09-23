using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Services;
using ECommerceApp.DTOs;
using System.Threading.Tasks;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserId }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.UserId)
            {
                return BadRequest("User ID mismatch");
            }

            var existingUser = await _userService.GetUserByIdAsync(userDto.UserId);
            if (existingUser == null)
            {
                return NotFound();
            }

            
            await _userService.UpdateUserAsync(userDto);

            return Ok(userDto);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
