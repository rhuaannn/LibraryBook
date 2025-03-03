using LibraryDomain.Entities;

namespace LibraryApplication.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid id);
        Task<User?> GetUserByIdAsync(Guid user);
    }
}
