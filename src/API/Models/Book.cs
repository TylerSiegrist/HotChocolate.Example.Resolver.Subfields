namespace API.Models;

public class Book
{
    public Book(string name)
    {
        this.Name = name;
    }
    public string Name { get; set; }
    public Author Author { get; set; } = new();
}
