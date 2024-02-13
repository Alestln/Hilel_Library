namespace Hilel_Library.Entities;

public class Library
{
    private readonly List<LibraryBook> _books;
    
    public IReadOnlyList<LibraryBook> Books => _books;

    public Library()
    {
        _books = new List<LibraryBook>();
    }

    public void Donate(Book? book)
    {
        if (book is null)
        {
            throw new NullReferenceException($"{nameof(Library)}, {nameof(Donate)}: Book is null");
        }

        _books.Add(LibraryBook.Create(book));
    }

    public IEnumerable<Book> SearchByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException($"{nameof(Library)}, {nameof(SearchByTitle)}: Title is is not valid.");
        }

        return _books
            .Where(b => b.Book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .Select(b => b.Book);
    }
    
    public IEnumerable<Book> SearchByAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException($"{nameof(Library)}, {nameof(SearchByAuthor)}: Author is is not valid.");
        }

        return _books
            .Where(b => b.Book.Authors.Any(a => a.Lastname.Contains(author, StringComparison.OrdinalIgnoreCase)
                                                || a.Firstname.Contains(author, StringComparison.OrdinalIgnoreCase)
                                                || a.Middlename.Contains(author, StringComparison.OrdinalIgnoreCase)))
            .Select(b => b.Book);
    }
    
    public IEnumerable<Book> SearchByPublishing(string publishing)
    {
        if (string.IsNullOrWhiteSpace(publishing))
        {
            throw new ArgumentException($"{nameof(Library)}, {nameof(SearchByPublishing)}: Publishing is not valid.");
        }
        
        return _books
            .Where(b => b.Book.Publishing.Contains(publishing, StringComparison.OrdinalIgnoreCase))
            .Select(b => b.Book);
    }
}