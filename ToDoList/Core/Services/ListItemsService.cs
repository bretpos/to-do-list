using System;
using ToDoList.Models;

namespace ToDoList.Core.Services
{
    // Currently, this class is just acting as a pass through to the repository.
    // This would be a great place for adding any business logic and validation.
    public class ListItemsService : IListItemsService
    {
        private IUnitOfWork _unitOfWork;

        public ListItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ListItem Add(ListItem listItem)
        {
            // Validate that there is a list with a ListId of listItem.ListId.

            listItem.CreatedOn = DateTime.Now;
            var newListItem = _unitOfWork.ListItems.Add(listItem);
            _unitOfWork.Complete();
            return newListItem;
        }

        public ListItem Get(int listItemId)
        {
            return _unitOfWork.ListItems.Get(listItemId);
        }

        public void Remove(ListItem listItem)
        {
            _unitOfWork.ListItems.Remove(listItem);
            _unitOfWork.Complete();
        }

        public ListItem Update(ListItem listItem, ListItem updatedListItem)
        {
            listItem.Description = updatedListItem.Description;
            listItem.IsCompleted = updatedListItem.IsCompleted;
            _unitOfWork.Complete();
            return listItem;
        }
    }
}