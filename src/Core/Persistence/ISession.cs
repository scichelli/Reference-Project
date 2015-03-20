namespace Headspring.Labs.Core.Persistence
{
    using System;
    using System.Collections.Generic;
    using Domain;

    public interface ISession
    {
        IEnumerable<Book> GetAll();
        void Add(Book book);
    }

    public class InMemorySession : ISession
    {
        private static readonly List<Book> Books = new List<Book>();

        public InMemorySession()
        {
            Books.Add(new Book{ Title = "Girl Genius", Id = Guid.NewGuid() });
            Books.Add(new Book{ Title = "American Gods", Id = Guid.NewGuid() });
            Books.Add(new Book{ Title = "Make: Electronics", Id = Guid.NewGuid() });
        }

        public IEnumerable<Book> GetAll()
        {
            return Books;
        }

        public void Add(Book book)
        {
            Books.Add(book);
        }
    }
}