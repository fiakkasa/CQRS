using SimpleSingleProject.Dtos;

namespace SimpleSingleProject.Repositories;

public interface IBookCommandsRepository
{
    ValueTask<long> SaveBook(BookInputDto book, CancellationToken cancellationToken = default);
}
