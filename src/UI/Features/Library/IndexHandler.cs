namespace Headspring.Labs.UI.Features.Library
{
    using System.Linq;
    using Core.Persistence;
    using Infrastructure;

    public class IndexHandler : IRequestHandler<IndexQuery, IndexViewModel> 
    {
        private readonly ISession _session;

        public IndexHandler(ISession session)
        {
            _session = session;
        }

        public IndexViewModel Handle(IndexQuery message)
        {
            var books = _session.GetAll();
            var model = new IndexViewModel
            {
                Books = books.Select(b => new IndexViewModel.BookViewModel{Id = b.Id, Title = b.Title}).ToList()
            };
            return model;
        }
    }

    public class IndexQuery : IRequest<IndexViewModel>
    {
    }
}