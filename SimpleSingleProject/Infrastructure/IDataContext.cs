using SimpleSingleProject.Models;

namespace SimpleSingleProject.Infrastructure
{
    public interface IDataContext
    {
        IQueryable<Book> Books { get; }

        ValueTask<long> AddBook(Book book, CancellationToken cancellationToken = default);
        ValueTask<Book?> GetBook(long id, CancellationToken cancellationToken = default);
    }
}