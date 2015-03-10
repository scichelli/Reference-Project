namespace Headspring.Labs.Tests.Features.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Domain;
    using Core.Persistence;
    using Should;
    using UI.Features.Library;

    public class IndexHandlerTests
    {
        public void Should_map_books_to_view()
        {
            var session = new FakeSession();
            session.AddBook("Book 1");
            session.AddBook("Book 2");
            session.AddBook("Book 3");
            var handler = new IndexHandler(session);

            var result = handler.Handle(new IndexQuery());

            result.Books.Count.ShouldEqual(3);
            result.Books.Any(b => b.Title == "Book 2").ShouldBeTrue("Should find a book from the persistence session in the mapped ViewModel");
        }

        public class FakeSession : ISession
        {
            private static readonly List<Book> Books = new List<Book>();

            public void AddBook(string title)
            {
                Books.Add(new Book{Id = Guid.NewGuid(), Title = title});
            }

            public IEnumerable<Book> GetAll()
            {
                return Books;
            }
        }
    }
}