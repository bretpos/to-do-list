using ToDoList.Models;

namespace ToDoList.Core.Services
{
    public interface IListItemsService
    {
        ListItem Get(int id);
        ListItem Add(ListItem listItem);
        void Remove(ListItem listItem);
        ListItem Update(ListItem listItem, ListItem updatedListItem);
    }
}
