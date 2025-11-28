namespace Blog.API.Models
{
    public class Post
    {
        public int Id { get; private set; }
        public int CategoryId { get; private set; }
        public int AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Sumary { get; private set; }
        public string Body { get; private set; }
        public string Slug { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set;}
        public List<Tag> Tags { get; private set; }

        public Post() { }

        public Post(int id, int categoryId, int authorId, string title, string sumary, string body, string slug, DateTime createDate, DateTime lastUpdateDate, List<Tag> tags)
        {
            Id = id;
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            Sumary = sumary;
            Body = body;
            Slug = slug;
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            Tags = tags;
        }

        public Post(int categoryId, int authorId, string title, string sumary, string body, string slug)
        {
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            Sumary = sumary;
            Body = body;
            Slug = slug;

            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }
    }
}
