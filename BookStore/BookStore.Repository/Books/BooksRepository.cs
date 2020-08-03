using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Books.Specifications;
using BookStore.Repository.Specifications;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Books
{
    public class BooksRepository:GenericRepository<Book>, IBooksRepository
    {
        public BooksRepository(BookStoreDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Book>> GetBooksByGenre(string genre)
        {
            ISpecification<Book> genreSpecification = new GenreSpecification(genre);
            var books =  _context.Books.Where(genreSpecification.ToExpression()).ToList();
            return books;
        }

        public async Task<IReadOnlyList<Book>> GetPremiumBooks()
        {
            ISpecification<Book> priceSpecification = new PriceSpecification(200);
            var premiumBooks = _context.Books.Where(b => priceSpecification.IsSatisfiedBy(b));
            return await premiumBooks.ToListAsync();
        }
        public async Task<IReadOnlyList<Book>> GetLatestBooks()
        {
            ISpecification<Book> priceSpecification = new PriceSpecification(300);
            var horrorBooks = _context.Books.Where(b => priceSpecification.IsSatisfiedBy(b));
            return await horrorBooks.ToListAsync();
        }
    }
}
