// RepositoryExtensions.cs (Optional, for Update method)
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories
{
    public static class RepositoryExtensions
    {
        public static void Update<TEntity>(this IRepository<TEntity> repository, TEntity entity) where TEntity : class
        {
            var context = ((Repository<TEntity>)repository).Context;
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
