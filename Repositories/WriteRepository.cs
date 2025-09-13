using Learn_Net.Data;
using Learn_Net.DTOs;
using Learn_Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_Net.Repositories
{
    public class WriteRepository: IWriteRepository
    {
        private readonly AppDbContext _db;
        public WriteRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(Write write) => await _db.Writes.AddAsync(write);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();

        public async Task<IEnumerable<WriteDto>> GetAllAsync()
        {
            var writes = await _db.Writes
                            .Include(w => w.UserWrites)
                            .ThenInclude(uw => uw.User)
                            .ToListAsync();
            return writes.Select(w => new WriteDto
            {
                Id = w.Id,
                Title = w.Title,
                Content = w.Content,
                Point = w.Point,
                IsPublished = w.IsPublished,
                Difficulty = w.Difficulty,
                Category = w.Category,
                Image = w.Image,
                UserWrites = w.UserWrites.Select(uw => new UserWriteDto
                {
                    UserId = uw.UserId,
                    Score = uw.Score,
                    AttemptCount = uw.AttemptCount,
                    IsCompleted = uw.IsCompleted
                })
            });
        }

        public async Task<List<Write>> GetAllWithUserWritesAsync()
        {
            return await _db.Writes
                            .Include(w => w.UserWrites)
                            .ToListAsync();
        }
    }
}
