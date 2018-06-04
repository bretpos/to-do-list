using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ToDoList.Core.Repositories;

namespace ToDoList.Persistence.Repositories.EF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        // Returns IEnumerable, not IQueryable. This encapsulates queries so
        // they are not repeated.
        public IEnumerable<TEntity> GetAll()
        {
            // By using ToList(), the query will be executed immediately. This prevents
            // the developer from building queries on these methods.
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}