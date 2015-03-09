namespace Headspring.Labs.UI.Features.Library
{
    using System;
    using Infrastructure;

    public class IndexHandler : IRequestHandler<IndexQuery, IndexViewModel> 
    {
        public IndexViewModel Handle(IndexQuery message)
        {
            throw new NotImplementedException();
        }
    }

    public class IndexQuery : IRequest<IndexViewModel>
    {
    }
}