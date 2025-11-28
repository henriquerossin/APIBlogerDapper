using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
using Blog.API.Repositories.Interfaces;
using Blog.API.Services.Interfaces;

namespace Blog.API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task CreatePostAsync(PostRequestDTO dto)
        {
            var post = new Post(
                dto.CategoryId,
                dto.AuthorId,
                dto.Title,
                dto.Sumary,
                dto.Body,
                dto.Slug
            );

            await _repository.CreatePostAsync(post, dto.Tags);
        }
    }

}
