namespace Headspring.Labs.Tests.Features.Library
{
    using System;
    using System.Linq;
    using Should;
    using UI.Features.Library;

    public class AddEditHandlerTests
    {
        public void Should_add_book_to_collection()
        {
            var session = new FakeSession();
            var handler = new AddEditHandler(session);
            var title = Guid.NewGuid().ToString();

            handler.Handle(new AddEditViewModel {Title = title});

            session.GetAll().Any(b => b.Title == title).ShouldBeTrue("Should map ViewModel to domain and send to session");
        }
    }
}