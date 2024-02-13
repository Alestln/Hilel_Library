using Hilel_Library.Entities;

namespace Hilel_Library;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.Donate(new Book(
            "Clear Code",
            new List<Author>
            {
                new Author("Kostin", "Oleksii", "Leonidovych")
            },
            "Wonder_Publish"));

        // Search by title
        // Приводил к списку для примера для переименования издательства книги
        var books = library.SearchByTitle("Clear Code").ToList();

        // Rename publishing
        books[0].RenamePublishing("Wonder");

        // Take book from library
        library.Books
            .FirstOrDefault(b => b.Book.Title.Contains("Clear Code", StringComparison.OrdinalIgnoreCase))
            ?.Take();
    }
}