using LibraryApplication.Interfaces;
using LibraryDomain.Entities;
using LibraryInfra.Connection;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class UseCaseBooks : IBookService
    {
        private readonly DbConnection _context;

        public UseCaseBooks(DbConnection context)
        {
            _context = context;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var createBook = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var deleteBook = await _context.Books.FindAsync(id);
            if (deleteBook == null)
            {
                throw new Exception("Book not found");
            }
            _context.Books.Remove(deleteBook);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            var bookId = await _context.Books.FindAsync(id);
            if (bookId == null)
            {
                throw new Exception("Book not found");
            }
            return bookId;
        }
    }
}
