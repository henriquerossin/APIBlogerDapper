namespace Blog.API.Models.DTOs
{
    public class PostResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sumary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public List<string> Tags { get; set; }
    }
}
