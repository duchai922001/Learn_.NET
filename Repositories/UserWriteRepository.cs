using Learn_Net.Data;
using Learn_Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_Net.Repositories
{
    public class UserWriteRepository: IUserWriteRepository
    {
        private readonly AppDbContext _db;
        public UserWriteRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserWrite> GetAsync(int userId, int writeId)
        {
            return await _db.UserWrites
                                   .FirstOrDefaultAsync(uw => uw.UserId == userId && uw.WriteId == writeId);
        }

        public async Task AddAsync(UserWrite userWrite)
        {
            await _db.UserWrites.AddAsync(userWrite);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
