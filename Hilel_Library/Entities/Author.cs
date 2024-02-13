namespace Hilel_Library.Entities;

public class Author
{
    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public string Middlename { get; set; }

    public Author(string lastname, string firstname, string middlename)
    {
        Lastname = lastname;
        Firstname = firstname;
        Middlename = middlename;
    }
}