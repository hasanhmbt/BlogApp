// Repository.cs
using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly AppDbContext Context;
        public readonly DbSet<TEntity> Entities;

        public Repository(AppDbContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }
    }
}
