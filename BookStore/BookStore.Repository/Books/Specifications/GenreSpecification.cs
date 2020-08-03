using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Specifications;
using System;
using System.Linq.Expressions;

namespace BookStore.Repository.Books.Specifications
{
    public class GenreSpecification : Specification<Book>
    {
        private readonly string _genre;
        public GenreSpecification(string genre)
        {
            _genre = genre;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.Genre == _genre;
        }
    }
}
