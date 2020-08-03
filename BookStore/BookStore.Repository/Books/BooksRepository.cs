using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Books.Specifications;
using BookStore.Repository.Specifications;

namespace BookStore.Repository.Books
{
    public class BooksRepository:GenericRepository<Book>, IBooksRepository
    {
        public BooksRepository(BookStoreDbContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetBooksByGenre(string Genre)
        {
            return _context.Books.Where(x => x.Genre == Genre);
        }

        public IEnumerable<Book> GetHorrorBooks()
        {
            ISpecification<Book> genreSpecification = new GenreSpecification<Book>("Horror");
            var horrorBooks = _context.Books.Where(b => genreSpecification.IsSatisfiedBy(b));
            return horrorBooks;
        }

        public IEnumerable<Book> GetPremiumBooks()
        {
            ISpecification<Book> genreSpecification = new GenreSpecification<Book>("Horror");
            var horrorBooks = _context.Books.Where(b => genreSpecification.IsSatisfiedBy(b));
            return horrorBooks;
        }

    }
}
