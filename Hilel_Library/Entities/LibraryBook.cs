namespace Hilel_Library.Entities;

public class LibraryBook
{
    public Book Book { get; private set; }
    public bool IsTaken { get; private set; }

    private LibraryBook(Book book)
    {
        Book = book;
        IsTaken = false;
    }

    public static LibraryBook Create(Book book)
    {
        return new LibraryBook(book);
    }

    public void Take()
    {
        IsTaken = true;
    }
    
    public void Return()
    {
        IsTaken = false;
    }
}