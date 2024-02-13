namespace Hilel_Library.Entities;

public class Book
{
    private readonly List<Author> _authors;
    
    public string Title { get; init; }
    public IReadOnlyList<Author> Authors => _authors;
    public string Publishing { get; set; }

    public Book(string title, IEnumerable<Author> authors, string publishing)
    {
        if (!authors.Any())
        {
            throw new ArgumentException($"{nameof(Book)}: The book must contain at least one author.");
        }

        Title = title;
        _authors = new(authors);
        Publishing = publishing;
    }

    public Book(string title, Author author, string publishing)
    {
        _authors = new List<Author>() { author };
        Title = title;
        Publishing = publishing;
    }
    
    public void RenamePublishing(string publishing)
    {
        if (string.IsNullOrWhiteSpace(publishing))
        {
            throw new ArgumentException($"{nameof(LibraryBook)}, {nameof(RenamePublishing)}: Publishing is is not valid.");
        }

        Publishing = publishing;
    }
}