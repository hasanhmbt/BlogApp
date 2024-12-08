namespace BlogApp.Models
{
    public class Article : Base
    {
        public string Title { get; set; }
        public string Description { get; set; } // Use for content
        public DateTime PublicationDate { get; set; }
        public string? FilePath { get; set; } // Path to the downloadable file
    }
}
