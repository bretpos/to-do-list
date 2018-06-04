using System.Collections.Generic;

namespace ToDoList.Core.Repositories
{
    public interface IListsRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IEnumerable<Models.List> GetListsWithListItems();
        Models.List GetListWithListItems(int listId);
    }
}
