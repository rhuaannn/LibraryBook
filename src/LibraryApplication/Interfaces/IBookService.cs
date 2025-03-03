using LibraryDomain.Entities;

namespace LibraryApplication.Interfaces
{
    public interface IBookService
    {
        Task<Book> CreateBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<bool> DeleteBookAsync(Guid id);
        Task<Book?> GetBookByIdAsync(Guid id);
    }
}
