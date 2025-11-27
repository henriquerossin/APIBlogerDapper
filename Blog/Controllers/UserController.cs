using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUserAsync(UserRequestDTO user)
        {
            await _userService.CreateUserAsync(user);

            return Created();
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByIDAsync(int id)
        {
            return Ok(await _userService.GetUserByIDAsync(id));
        }

        [HttpPut("UpdateByID/{id}")]
        public async Task<ActionResult> UpdateUserByIDAsync(UserRequestDTO user, int id)
        {
            var userFound = await _userService.GetUserByIDAsync(id);

            if(userFound is null)
            {
                return NotFound();
            }
            await _userService.UpdateUserByIDAsync(user, id);
            return Ok();
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult> DeleteUserByIDAsync(int id)
        {
            var userFound = await _userService.GetUserByIDAsync(id);

            if (userFound is null)
            {
                return NotFound();
            }
            await _userService.DeleteUserByIDAsync(id);
            return Ok();
        }
    }
}
