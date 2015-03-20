namespace Headspring.Labs.Tests.Features.Library
{
    using System.Linq;
    using Core.Persistence;
    using Should;
    using UI.Features.Library;

    public class IndexHandlerTests
    {
        private readonly ISession _session;

        public IndexHandlerTests(ISession session)
        {
            _session = session;
        }

        public void Should_map_books_to_view()
        {
            var fakeSession = new FakeSession();
            fakeSession.AddBook("Book 1");
            fakeSession.AddBook("Book 2");
            fakeSession.AddBook("Book 3");
            var handler = new IndexHandler(fakeSession);

            var result = handler.Handle(new IndexQuery());

            result.Books.Count.ShouldEqual(3);
            result.Books.Any(b => b.Title == "Book 2").ShouldBeTrue("Should find a book from the persistence session in the mapped ViewModel");
        }

        /// <summary>
        /// This is not testing anything useful; instead it is demonstrating that, if you want your test to use the same 
        /// StructureMap-provided instance that your production code will get, you can take the interface as an argument 
        /// to the test fixture class's constructor.
        /// </summary>
        public void Should_do_something_to_demo_the_ISession_fetched_from_StructureMap()
        {
            var handler = new IndexHandler(_session);

            var result = handler.Handle(new IndexQuery());

            result.Books.Any(b => b.Title == "Girl Genius").ShouldBeTrue("Should find a book from our concrete implementation of ISession");
        }
    }
}