namespace Headspring.Labs.Tests.Features.Library
{
    using System;
    using System.Collections.Generic;
    using Core.Domain;
    using Core.Persistence;

    public class FakeSession : ISession
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(string title)
        {
            Add(new Book { Id = Guid.NewGuid(), Title = title });
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }
    }
}