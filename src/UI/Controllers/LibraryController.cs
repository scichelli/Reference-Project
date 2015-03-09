namespace Headspring.Labs.UI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Features.Library;

    public class LibraryController : Controller
    {
        public ViewResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Books = new List<IndexViewModel.BookViewModel>
                {
                    new IndexViewModel.BookViewModel{Title = "Girl Genius"},
                    new IndexViewModel.BookViewModel{Title = "American Gods"},
                    new IndexViewModel.BookViewModel{Title = "Make: Electronics"},
                }
            };
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