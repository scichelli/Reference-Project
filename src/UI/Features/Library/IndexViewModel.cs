namespace Headspring.Labs.UI.Features.Library
{
    using System.Collections.Generic;
    using System;

    public class IndexViewModel
    {
        public IList<BookViewModel> Books { get; set; }

        public class BookViewModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
        }
    }
}