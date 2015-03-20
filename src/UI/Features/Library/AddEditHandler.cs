namespace Headspring.Labs.UI.Features.Library
{
    using Core.Domain;
    using Core.Persistence;
    using Infrastructure;

    public class AddEditHandler : IRequestHandler<AddEditViewModel, Book>
    {
        private readonly ISession _session;

        public AddEditHandler(ISession session)
        {
            _session = session;
        }

        public Book Handle(AddEditViewModel message)
        {
            if (message.Id != null)
                throw new System.NotImplementedException(); //Edit not yet implemented.

            var book = new Book {Title = message.Title};
            _session.Add(book);
            return book;
        }
    }
}