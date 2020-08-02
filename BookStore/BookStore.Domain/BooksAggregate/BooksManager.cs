using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Domain.BooksAggregate.Specifications;
using BookStore.Domain.Specifications;

namespace BookStore.Domain.BooksAggregate
{
    public class BooksManager
    {
        private List<Book> _books;
        public BooksManager()
        {
            _books = new List<Book>();
        }

        public IEnumerable<Book> GetHorrorBooks()
        {
            ISpecification<Book> genreSpecification = new GenreSpecification<Book>("Horror");
            var horrorBooks = _books.FindAll(b => genreSpecification.IsSatisfiedBy(b));


        }
    }
}
