using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Specifications;

namespace BookStore.Repository.Books.Specifications
{
    public class PriceSpecification<T> : GenericSpecification<T>
    {
        private readonly double _price;
        public PriceSpecification(int price)
        {
            this._price = price;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return entity != null && (entity as Book)?.Price == this._price;
        }
    }
}
