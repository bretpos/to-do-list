using System;
using System.Web.Http;
using ToDoList.Core;
using ToDoList.Models;
using ToDoList.Persistence;

namespace ToDoList.Controllers.Api
{
    public class ListItemsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        // Should accept an IUnitOfWork here and use dependency injection.
        // This would decouple this class from its dependencies and improve testability.
        public ListItemsController()
        {
            _unitOfWork = new UnitOfWork(new ToDoListContext());
        }

        [HttpPost]
        public IHttpActionResult Create(ListItem listItem)
        {
            if (listItem == null)
                return BadRequest();

            listItem.CreatedOn = DateTime.Now;
            var newListItem = _unitOfWork.ListItems.Add(listItem);
            _unitOfWork.Complete();

            return Created($"{Request.RequestUri}/{newListItem.ListItemId}", newListItem);
        }

        [HttpPut]
        public IHttpActionResult Put(ListItem listItem)
        {
            if (listItem == null)
                return BadRequest();

            var item = _unitOfWork.ListItems.Get(listItem.ListItemId);

            if (item == null)
                return NotFound();

            item.Description = listItem.Description;
            item.IsCompleted = listItem.IsCompleted;

            _unitOfWork.Complete();

            return Ok(item);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var listItem = _unitOfWork.ListItems.Get(id);

            if (listItem == null)
                return NotFound();

            _unitOfWork.ListItems.Remove(listItem);
            _unitOfWork.Complete();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
