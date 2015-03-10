namespace Headspring.Labs.Tests.Features.Library
{
    using System.Linq;
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
    }
}