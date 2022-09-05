using SimpleSingleProject.Models;

namespace SimpleSingleProject.Dtos;

public record BookDto(
    long Id,
    string Title,
    string ISBN,
    long Pages,
    PublicationType PublicationType,
    DateTimeOffset PublishedDate
)
{
    public long NumberOfDaysPublished => Convert.ToInt64((DateTimeOffset.Now - PublishedDate).TotalDays);
}
