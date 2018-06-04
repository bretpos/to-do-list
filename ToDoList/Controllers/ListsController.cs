using System.Web.Mvc;
using ToDoList.Core;
using ToDoList.Persistence;

namespace ToDoList.Controllers
{
    public class ListsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        // Should accept an IUnitOfWork here and use dependency injection.
        // This would decouple this class from its dependencies and improve testability.
        public ListsController()
        {
            _unitOfWork = new UnitOfWork(new ToDoListContext());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}