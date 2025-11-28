using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(PostRequestDTO dto);
    }
}
