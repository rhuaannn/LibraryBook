using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.Entities;

public class Book
{
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();

    [Required]
    public string Title { get; private set; } = string.Empty;
    [Required]
    public string Author { get; private set; } = string.Empty;
    [Required]
    public string Description { get; private set; } = string.Empty;
    [Required]
    public DateTime PublishedDate { get; private set; } = DateTime.Now;

    public Book(string title, string author, string description, DateTime publishedDate)
    {
        Title = title;
        Author = author;
        Description = description;
        PublishedDate = publishedDate;

    }
}
