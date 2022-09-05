namespace SimpleSingleProject.Models;

public record Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public long Pages { get; set; }
    public PublicationType PublicationType { get; set; }
    public DateTimeOffset PublishedDate { get; set; }
}
