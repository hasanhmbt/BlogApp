using BlogApp.Models;

public class User : Base
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public string? Specialty { get; set; }
    public string? ScientificFacts { get; set; }
    public string? Email { get; set; }
    public string? ProfileImageUrl { get; set; }
    public ICollection<Article>? Articles { get; set; }  
}
