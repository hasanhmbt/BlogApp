namespace BlogApp.Models;

public class Subject :Base
{
    public string Name { get; set; }  
    public int Hours { get; set; }  
    public string? MaterialsLink { get; set; }  
    public int Credits { get; set; }  
}
