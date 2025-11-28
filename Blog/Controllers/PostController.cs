using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDTO dto)
        {
            await _postService.CreatePostAsync(dto);
            return Ok("Post criado com sucesso");
        }
    }
}