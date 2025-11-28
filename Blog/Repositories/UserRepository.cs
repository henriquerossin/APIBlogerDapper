using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var sql = "SELECT Name,Email,PasswordHash,Bio,Image,Slug FROM [User]";
            return (await _connection.QueryAsync<UserResponseDTO>(sql)).ToList();
        }

        public async Task CreateUserAsync(User user)
        {
            var sql = "INSERT INTO [User] (Name,Email,PasswordHash,Bio,Image,Slug) VALUES (@Name,@Email,@PasswordHash,@Bio,@Image,@Slug)";
            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug });
        }

        public async Task<UserResponseDTO> GetUserByIDAsync(int id)
        {
            var sql = "SELECT Name,Email,PasswordHash,Bio,Image,Slug FROM [User] WHERE Id = @UserID";
            return await _connection.QueryFirstOrDefaultAsync<UserResponseDTO>(sql, new { UserID = id });
        }

        public async Task UpdateUserByIDAsync(User user, int id)
        {
            var sql = "UPDATE [User] SET Name = @Name, Email = @Email, @PasswordHash = @PasswordHash,Bio = @Bio,Image = @Image, Slug = @Slug WHERE Id = @UserID";
            await _connection.ExecuteAsync(sql, new { user.Name, user.Email, user.PasswordHash, user.Bio, user.Image, user.Slug, UserID = id });
        }

        public async Task DeleteUserByIDAsync(int id)
        {
            var sql = "DELETE FROM [User] WHERE Id = @UserID";
            await _connection.ExecuteAsync(sql, new { UserID = id });
        }

        public async Task<List<UserResponseDTO>> GetAllUserRoles()
        {
            var usersDict = new Dictionary<int, UserResponseDTO>();

            var sql =
                @"SELECT u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug, r.Name, r.Slug
                FROM [User] u
                JOIN UserRole ur
                ON u.id = ur.UserId
                JOIN [Role] r
                ON r.Id = ur.RoleId";

            await _connection.QueryAsync<User, Role, User>(
                sql,
                (user, role) =>
                {
                    if (!usersDict.ContainsKey(user.Id))
                    {
                        usersDict[user.Id] = new UserResponseDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            PasswordHash = user.PasswordHash,
                            Bio = user.Bio,
                            Image = user.Image,
                            Slug = user.Slug,
                            Roles = new List<string>()
                        };
                    }
                    usersDict[user.Id].Roles.Add(role.Name);
                    return user;
                },
                splitOn: "Name"
            );
            return usersDict.Values.ToList();
        }

        public async Task<List<UserResponseDTO>> GetUserRoleById()
        {
            var usersDict = new Dictionary<int, UserResponseDTO>();

            var sql =
                @"SELECT u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug, r.Name, r.Slug
                FROM [User] u
                JOIN UserRole ur
                ON u.id = ur.UserId
                JOIN [Role] r
                ON r.Id = ur.RoleId
                WHERE u.Id = @Id";

            await _connection.QueryAsync<User, Role, User>(
                sql,
                (user, role) =>
                {
                    if (!usersDict.ContainsKey(user.Id))
                    {
                        usersDict[user.Id] = new UserResponseDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            PasswordHash = user.PasswordHash,
                            Bio = user.Bio,
                            Image = user.Image,
                            Slug = user.Slug,
                            Roles = new List<string>()
                        };
                    }
                    usersDict[user.Id].Roles.Add(role.Name);
                    return user;
                },
                splitOn: "Name"
            );
            return usersDict.Values.ToList();
        }
    }
}
