namespace Headspring.Labs.UI.Features.Library
{
    using System.Collections.Generic;
    using Infrastructure;

    public class IndexHandler : IRequestHandler<IndexQuery, IndexViewModel> 
    {
        public IndexViewModel Handle(IndexQuery message)
        {
            var model = new IndexViewModel
            {
                Books = new List<IndexViewModel.BookViewModel>
                {
                    new IndexViewModel.BookViewModel{Title = "Girl Genius"},
                    new IndexViewModel.BookViewModel{Title = "American Gods"},
                    new IndexViewModel.BookViewModel{Title = "Make: Electronics"},
                }
            };
            return model;
        }
    }

    public class IndexQuery : IRequest<IndexViewModel>
    {
    }
}