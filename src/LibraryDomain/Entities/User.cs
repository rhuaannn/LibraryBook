using System.ComponentModel.DataAnnotations;
using LibraryDomain.ValueObject;

namespace LibraryDomain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Name Name { get; set; } 

        [Required]
        public Password Password { get; set; }

        [Required]
        public Email Email { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
        public User(string name, string password, string email)
        {
            Name = new Name(name);
            Password = new Password(password);
            Email = new Email(email);
        }

        public User()
        {
            
        }

        public void AddBook(Book book)
        {
            book.AssignUser(this);
            Books.Add(book);
        }
    }
}
