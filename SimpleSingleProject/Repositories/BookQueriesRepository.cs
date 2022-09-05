using SimpleSingleProject.Infrastructure;
using SimpleSingleProject.Models;

namespace SimpleSingleProject.Repositories;

public class BookQueriesRepository : IBookQueriesRepository
{
    private readonly IDataContext _dataContext;

    public BookQueriesRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IQueryable<Book> GetAll() => _dataContext.Books;

    public async ValueTask<Book?> FindById(long id, CancellationToken cancellationToken = default) =>
        await _dataContext.GetBook(id, cancellationToken);
}
