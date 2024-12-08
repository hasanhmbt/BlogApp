// IUnitOfWork.cs
using BlogApp.Models;
using System;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<User> Users { get; }
        IRepository<DownloadFiles> DownloadFiles { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
