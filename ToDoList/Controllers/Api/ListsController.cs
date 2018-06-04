using System.Web.Http;
using ToDoList.Core;
using ToDoList.Models;
using ToDoList.Persistence;

namespace ToDoList.Controllers.Api
{
    public class ListsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        // Should accept an IUnitOfWork here and use dependency injection.
        // This would decouple this class from its dependencies and improve testability.
        public ListsController()
        {
            _unitOfWork = new UnitOfWork(new ToDoListContext());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var list = _unitOfWork.Lists.Get(id);

            if (list == null)
                return NotFound();

            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var lists = _unitOfWork.Lists.GetListsWithListItems();
            return Ok(lists);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] List list)
        {
            if (list == null)
                return BadRequest();

            var newList = _unitOfWork.Lists.Add(list);
            _unitOfWork.Complete();

            return Created($"{Request.RequestUri}/{newList.ListId}", newList);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] List updateList)
        {
            if (updateList == null)
                return base.BadRequest();

            var list = _unitOfWork.Lists.Get((int)updateList.ListId);

            if (list == null)
                return NotFound();

            list.Title = updateList.Title;
            list.IsActive = updateList.IsActive;

            _unitOfWork.Complete();

            return Ok(list);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var list = _unitOfWork.Lists.GetListWithListItems(id);

            if (list == null)
                return NotFound();

            _unitOfWork.ListItems.RemoveRange(list.ListItems);
            _unitOfWork.Lists.Remove(list);
            _unitOfWork.Complete();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
