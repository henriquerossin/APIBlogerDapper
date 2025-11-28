using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SqlConnection _connection;

        public PostRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task CreatePostAsync(Post post, List<string> tags)
        {
            var sql =
                @"INSERT INTO Post (CategoryId, AuthorId, Title, Summary, Body, Slug, CreateDate, LastUpdateDate)
                  OUTPUT INSERTED.Id
                  VALUES (@CategoryId, @AuthorId, @Title, @Sumary, @Body, @Slug, @CreateDate, @LastUpdateDate);";

            var postId = await _connection.ExecuteScalarAsync<int>(sql, new
            {
                post.CategoryId,
                post.AuthorId,
                post.Title,
                post.Sumary,
                post.Body,
                post.Slug,
                post.CreateDate,
                post.LastUpdateDate
            });

            foreach (var tagName in tags)
            {
                var tagId = await _connection.ExecuteScalarAsync<int?>(
                    "SELECT Id FROM Tag WHERE Name = @Name",
                    new { Name = tagName }
                );

                if (tagId == null)
                {
                    var slug = tagName
                        .ToLower()
                        .Replace(" ", "-")
                        .Replace("#", "")
                        .Replace("ç", "c");

                    tagId = await _connection.ExecuteScalarAsync<int>(
                        @"INSERT INTO Tag (Name, Slug)
                          OUTPUT INSERTED.Id
                          VALUES (@Name, @Slug)",
                        new { Name = tagName, Slug = slug }
                    );
                }

                await _connection.ExecuteAsync(
                    "INSERT INTO PostTag (PostId, TagId) VALUES (@PostId, @TagId)",
                    new { PostId = postId, TagId = tagId }
                );
            }
        }
    }
}
