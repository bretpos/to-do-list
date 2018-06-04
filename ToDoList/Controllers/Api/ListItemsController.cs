using System.Web.Http;
using ToDoList.Core.Services;
using ToDoList.Models;
using ToDoList.Persistence;

namespace ToDoList.Controllers.Api
{
    public class ListItemsController : ApiController
    {
        private IListItemsService _listItemsService;

        // Should accept an IListItemsService here and use dependency injection.
        // This would decouple this class from its dependencies and improve testability.
        public ListItemsController()
        {
            _listItemsService = new ListItemsService(new UnitOfWork(new ToDoListContext()));
        }

        [HttpPost]
        public IHttpActionResult Create(ListItem listItem)
        {
            if (listItem == null)
                return BadRequest();

            var newListItem = _listItemsService.Add(listItem);

            return Created($"{Request.RequestUri}/{newListItem.ListItemId}", newListItem);
        }

        [HttpPut]
        public IHttpActionResult Put(ListItem listItem)
        {
            if (listItem == null)
                return BadRequest();

            var item = _listItemsService.Get(listItem.ListItemId);

            if (item == null)
                return NotFound();

            _listItemsService.Update(item, listItem);

            return Ok(item);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var listItem = _listItemsService.Get(id);

            if (listItem == null)
                return NotFound();

            _listItemsService.Remove(listItem);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
