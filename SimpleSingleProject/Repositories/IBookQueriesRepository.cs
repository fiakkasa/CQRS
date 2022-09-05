using SimpleSingleProject.Models;

namespace SimpleSingleProject.Repositories;

public interface IBookQueriesRepository
{
    IQueryable<Book> GetAll();
    ValueTask<Book?> FindById(long id, CancellationToken cancellationToken = default);
}
