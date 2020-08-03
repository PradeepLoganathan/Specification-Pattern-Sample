using BookStore.Domain.BooksAggregate;
using System;
using System.Linq.Expressions;

namespace BookStore.Repository.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T o);
        Expression<Func<T, bool>> ToExpression();
    }
}
