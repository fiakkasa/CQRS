using SimpleSingleProject.Dtos;
using SimpleSingleProject.Repositories;

namespace SimpleSingleProject.Commands;

public class BookCommands : IBookCommands
{
    private readonly IBookCommandsRepository _bookCommandsRepository;

    public BookCommands(IBookCommandsRepository bookCommandsRepository)
    {
        _bookCommandsRepository = bookCommandsRepository;
    }

    public async ValueTask<long> SaveBook(BookInputDto book, CancellationToken cancellationToken = default) =>
        await _bookCommandsRepository.SaveBook(book, cancellationToken);
}
