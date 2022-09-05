using SimpleSingleProject.Dtos;
using SimpleSingleProject.Repositories;

namespace SimpleSingleProject.Queries;

public class BookQueries : IBookQueries
{
    private readonly IBookQueriesRepository _bookQueriesRepository;

    public BookQueries(IBookQueriesRepository bookQueriesRepository)
    {
        _bookQueriesRepository = bookQueriesRepository;
    }

    public IQueryable<BookDto> GetAll() =>
        _bookQueriesRepository
            .GetAll()
            .Select(obj => new BookDto(
                obj.Id,
                obj.Title,
                obj.ISBN,
                obj.Pages,
                obj.PublicationType,
                obj.PublishedDate
            ));

    public async ValueTask<BookDto?> FindById(long id, CancellationToken cancellationToken = default) =>
        await _bookQueriesRepository.FindById(id, cancellationToken) switch
        {
            { } obj => new BookDto(
                obj.Id,
                obj.Title,
                obj.ISBN,
                obj.Pages,
                obj.PublicationType,
                obj.PublishedDate
            ),
            _ => default
        };
}
