// IArticleRepository.cs
using BlogApp.Models;
using System.Collections.Generic;

namespace BlogApp.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetLatestArticles(int count);
    }
}
