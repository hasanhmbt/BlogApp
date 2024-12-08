namespace BlogApp.Models;

public class DownloadFiles:Base
{
    public string Name { get; set; } // File Name
    public string FilePath { get; set; } // Path or URL to the file
    public string FileType { get; set; } // Type (e.g., pdf, docx, zip)
    public DateTime UploadDate { get; set; } // Date the File was Uploaded
}
