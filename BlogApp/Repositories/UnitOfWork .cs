// UnitOfWork.cs
using BlogApp.Data;
using BlogApp.Models;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IArticleRepository Articles { get; }
        public IRepository<Subject> Subjects { get; }
        public IRepository<User> Users { get; }
        public IRepository<DownloadFiles> DownloadFiles { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Articles = new ArticleRepository(_context);
            Subjects = new Repository<Subject>(_context);
            Users = new Repository<User>(_context);
            DownloadFiles = new Repository<DownloadFiles>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
