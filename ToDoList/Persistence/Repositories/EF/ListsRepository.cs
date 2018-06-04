using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoList.Core.Repositories;
using ToDoList.Models;

namespace ToDoList.Persistence.Repositories.EF
{
    public class ListsRepository<TEntity> : Repository<TEntity>, IListsRepository<TEntity> where TEntity : class
    {
        public ListsRepository(DbContext context) : base(context) { }

        public ToDoListContext ToDoListContext
        {
            get { return Context as ToDoListContext; }
        }

        public IEnumerable<List> GetListsWithListItems()
        {
            return ToDoListContext.Lists
                                  .Include(list => list.ListItems)
                                  .ToList();
        }

        public List GetListWithListItems(int listId)
        {
            return ToDoListContext.Lists
                                  .Include(list => list.ListItems)
                                  .SingleOrDefault(list => list.ListId == listId);
        }
    }
}