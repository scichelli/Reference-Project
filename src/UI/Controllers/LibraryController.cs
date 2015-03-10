namespace Headspring.Labs.UI.Controllers
{
    using System.Web.Mvc;
    using Core.Domain;
    using Core.Persistence;
    using Features.Library;

    public class LibraryController : Controller
    {
        private static readonly ISession _session = new InMemorySession();

        public ViewResult Index()
        {
            var viewModel = new IndexHandler(_session).Handle(new IndexQuery());
            return View(viewModel);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddEditViewModel model)
        {
            _session.Add(new Book {Title = model.Title});
            return RedirectToAction("Index");
        }
    }
}