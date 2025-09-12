using Learn_Net.Models;

namespace Learn_Net.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User> RegisterAsync(string fullName, string email, string password);
        Task<User?> AuthenticateAsync(string email, string password);
    }
}
