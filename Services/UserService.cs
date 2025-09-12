using Learn_Net.Models;
using Learn_Net.Repositories;

namespace Learn_Net.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _repo.GetByEmailAsync(email);
            if (user == null) return null;
            bool verified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return verified ? user : null;
        }

        public async Task<User> RegisterAsync(string fullName, string email, string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { FullName = fullName, Email = email, PasswordHash = hash };
            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email) => await _repo.GetByEmailAsync(email);
        public async Task<User?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    }
}
