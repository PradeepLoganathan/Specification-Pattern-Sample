using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Domain.BooksAggregate
{
    public interface IBooksRepository :IGenericRepository<Book>
    {
        Task<IReadOnlyList<Book>> GetBooksByGenre(string genre);
        Task<IReadOnlyList<Book>> GetLatestBooks();
        Task<IReadOnlyList<Book>> GetPremiumBooks();
    }
}
