using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ToDoList.Core.Repositories
{
    // Acts as an in-memory collection.
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
