using System;
using System.Linq.Expressions;
using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Specifications;

namespace BookStore.Repository.Books.Specifications
{
    public class DateSpecification:Specification<Book>
    {
        private readonly DateTime _publishDate;
        public DateSpecification(DateTime publishDate)
        {
            this._publishDate = publishDate;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.PublishDate == _publishDate;
        }
    }
}
