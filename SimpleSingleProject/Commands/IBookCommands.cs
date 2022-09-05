using SimpleSingleProject.Dtos;

namespace SimpleSingleProject.Commands;

// like GraphQL Mutations
public interface IBookCommands
{
    ValueTask<long> SaveBook(BookInputDto book, CancellationToken cancellationToken = default);
}
