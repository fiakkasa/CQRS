using SimpleSingleProject.Models;
using System.Collections.Concurrent;


namespace SimpleSingleProject.Infrastructure;

public class DataContext : IDataContext
{
    private readonly object _addLock = new object();
    private readonly ConcurrentBag<Book> _books = new(
        Enumerable.Range(1, 100)
            .Select(x => new Book
            {
                Id = x,
                Title = $"Title {x}",
                ISBN = $"ISBN-{x}",
                Pages = Random.Shared.Next(100, 300),
                PublicationType = (x % 3) switch
                {
                    0 => PublicationType.HardCover,
                    1 => PublicationType.SoftCover,
                    _ => PublicationType.Digital
                },
                PublishedDate = DateTimeOffset.Now.AddDays(-Random.Shared.Next(0, 100))
            })
    );

    public IQueryable<Book> Books => _books.AsQueryable();

    public async ValueTask<Book?> GetBook(long id, CancellationToken cancellationToken = default) =>
        await _books.ToAsyncEnumerable().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async ValueTask<long> AddBook(Book book, CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);

        var id = 0L;

        lock (_addLock)
        {
            id = DateTimeOffset.Now.ToUnixTimeSeconds();
            var newItem = book with
            {
                Id = id,
                PublishedDate = DateTimeOffset.Now
            };

            _books.Add(newItem);
        }

        return await Task.FromResult(id);
    }
}
