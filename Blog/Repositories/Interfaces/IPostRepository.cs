using Blog.API.Models;

namespace Blog.API.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task CreatePostAsync(Post post, List<string> tags);
    }
}
