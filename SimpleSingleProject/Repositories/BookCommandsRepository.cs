using SimpleSingleProject.Dtos;
using SimpleSingleProject.Infrastructure;
using SimpleSingleProject.Models;

namespace SimpleSingleProject.Repositories;

public class BookCommandsRepository : IBookCommandsRepository
{
    private readonly IDataContext _dataContext;

    public BookCommandsRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async ValueTask<long> SaveBook(BookInputDto book, CancellationToken cancellationToken = default) =>
        await _dataContext.AddBook(new Book
        {
            ISBN = book.ISBN,
            Pages = book.Pages,
            PublicationType = book.PublicationType,
            Title = book.Title
        });
}