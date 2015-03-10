namespace Headspring.Labs.UI.Controllers
{
    using System.Web.Mvc;
    using Core.Persistence;
    using Features.Library;

    public class LibraryController : Controller
    {
        private readonly ISession _session;

        public LibraryController(ISession session)
        {
            _session = session;
        }

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
            new AddEditHandler(_session).Handle(model);
            return RedirectToAction("Index");
        }
    }
}