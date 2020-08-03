using BookStore.Domain.BooksAggregate;
using BookStore.Repository.Specifications;


namespace BookStore.Repository.Books.Specifications
{
    public class GenreSpecification<T> : GenericSpecification<T>
    {
        private readonly string _genre;
        public GenreSpecification(string genre)
        {
            _genre = genre;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return entity != null && (entity as Book)?.Genre == this._genre;
        }
    }
}
