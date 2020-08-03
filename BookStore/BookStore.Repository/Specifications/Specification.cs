using System;
using System.Linq.Expressions;

namespace BookStore.Repository.Specifications
{
    public abstract class Specification<T>:ISpecification<T>
    {
        public abstract Expression<Func<T , bool>> ToExpression();
 
        public bool IsSatisfiedBy(T entity)
        {
            Func<T , bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

    }
}
