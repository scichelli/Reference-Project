namespace Headspring.Labs.UI.Controllers
{
    using System.Web.Mvc;
    using Features.Library;

    public class LibraryController : Controller
    {
        public ViewResult Index()
        {
            var viewModel = new IndexHandler().Handle(new IndexQuery());
            return View(viewModel);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddEditViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}