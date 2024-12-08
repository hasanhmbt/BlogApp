namespace BlogApp.Models
{
    public class Work : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DatePublished { get; set; }
        public string Url { get; set; } // Link to the work, if applicable
    }

}
