using System;
using ToDoList.Core.Repositories;

namespace ToDoList.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IListsRepository<Models.List> Lists { get; }
        IRepository<Models.ListItem> ListItems { get; }
        int Complete();
    }
}
