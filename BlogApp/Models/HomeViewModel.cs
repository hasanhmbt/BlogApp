using System.Collections.Generic;

namespace BlogApp.Models
{
    public class HomeViewModel
    {
        public User User { get; set; }
        public IEnumerable<Article> LatestArticles { get; set; }
        public IEnumerable<DownloadFiles> LatestFiles { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
