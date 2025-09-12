using Learn_Net.Data;
using Learn_Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_Net.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(User user) => await _db.Users.AddAsync(user);

        public async Task DeleteAsync(User user)
        {
            _db.Users.Remove(user);
            await Task.CompletedTask; 
        }

        public async Task<User?> GetByEmailAsync(string email) =>
           await _db.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> GetByIdAsync(int id) => await _db.Users.FindAsync(id);

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
