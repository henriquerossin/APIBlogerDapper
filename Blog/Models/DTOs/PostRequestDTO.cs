namespace Blog.API.Models.DTOs
{
    public class PostRequestDTO
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Sumary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public List<string> Tags { get; set; }
    }
}
