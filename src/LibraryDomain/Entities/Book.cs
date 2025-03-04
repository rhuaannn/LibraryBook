using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryDomain.Entities;

public class Book
{
    [Key] public Guid Id { get; private set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Title Obrigatório!")]
    public string Title { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Author Obrigatório!")]
    public string Author { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Descrição Obrigatório!")]
    public string Description { get; private set; } = string.Empty;

    [Required(ErrorMessage = "Data Obrigatório!")]
    public DateTime PublishedDate { get; private set; } = DateTime.Now;

    public Guid? UserId { get; private set; }

    [JsonIgnore]
    public virtual User? User { get; private set; }

    public Book(string title, string author, string description, DateTime publishedDate)
    {
        Title = title;
        Author = author;
        Description = description;
        PublishedDate = publishedDate;
    }
    public Book(){}

    public Book(string title, string author, string description, DateTime publishedDate, Guid? userId = null)
        : this(title, author, description, publishedDate)
    {
        UserId = userId;
    }

    public void AssignUser(User user)
    {
        User = user?? throw new ArgumentNullException(nameof(user));
        UserId = user.Id;
    }
}