using SimpleSingleProject.Dtos;

namespace SimpleSingleProject.Queries;

// like GraphQL Queries
public interface IBookQueries
{
    IQueryable<BookDto> GetAll();
    ValueTask<BookDto?> FindById(long id, CancellationToken cancellationToken = default);
}
