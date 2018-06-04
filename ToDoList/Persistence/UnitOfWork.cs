using ToDoList.Core;
using ToDoList.Core.Repositories;
using ToDoList.Models;

namespace ToDoList.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoListContext _context;

        public UnitOfWork(ToDoListContext context)
        {
            _context = context;
            Lists = new Repositories.EF.ListsRepository<List>(_context);
            ListItems = new Repositories.EF.Repository<ListItem>(_context);
        }

        public IListsRepository<List> Lists { get; private set; }
        public IRepository<ListItem> ListItems { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}