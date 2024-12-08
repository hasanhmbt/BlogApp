// ArticleRepository.cs
using BlogApp.Data;
using BlogApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Article> GetLatestArticles(int count)
        {
            return Context.Set<Article>()
                .OrderByDescending(a => a.PublicationDate)
                .Take(count)
                .ToList();
        }
    }
}
