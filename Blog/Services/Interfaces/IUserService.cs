using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();

        Task CreateUserAsync(UserRequestDTO user);

        Task<UserResponseDTO> GetUserByIDAsync(int id);

        Task UpdateUserByIDAsync(UserRequestDTO user, int id);

        Task DeleteUserByIDAsync(int id);
    }
}
