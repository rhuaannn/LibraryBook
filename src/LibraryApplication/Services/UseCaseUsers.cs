using LibraryApplication.Interfaces;
using LibraryDomain.Entities;
using LibraryInfra.Connection;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class UseCaseUsers : IUserService
    {
        private readonly DbConnection _context; 

        public UseCaseUsers(DbConnection context) 
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if(await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                throw new Exception("Email already exists");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var user = await _context.Users.ToListAsync();
            return user;

        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
               throw new Exception("User not found");
            }
            return await _context.Users.FindAsync(userId);

        }
    }
}
