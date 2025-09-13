using Learn_Net.DTOs;
using Learn_Net.Enums;
using Learn_Net.Models;
using Learn_Net.Repositories;

namespace Learn_Net.Services
{
    public class WriteService: IWriteService
    {
        private readonly IWriteRepository _repo;
        public WriteService(IWriteRepository repo) => _repo = repo;

        public async Task<Write> CreateAsync(
           string title,
           string content,
           DifficultyLevel difficulty = DifficultyLevel.Easy,
           WriteCategory category = WriteCategory.Other,
           string? image = null,
           int point = 0,
           bool isPublished = true
       )
        {
            var write = new Write
            {
                Title = title,
                Content = content,
                Difficulty = difficulty,
                Category = category,
                Image = image,
                Point = point,
                IsPublished = isPublished
            };
            await _repo.AddAsync( write );
            await _repo.SaveChangesAsync();
            return write;
        }

        public async Task<IEnumerable<WriteDto>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<CategoryWithWritesDto>> GetGroupedByCategoryAsync(int userId)
        {
            var writes = await _repo.GetAllWithUserWritesAsync();
            var grouped = writes
                .GroupBy(x => x.Category)
                .Select(g => new CategoryWithWritesDto
                {
                    Category = g.Key.ToString(),
                    Writes = g.Select(w => new WriteDtoByUser
                    {
                        Id = w.Id,
                        Title = w.Title,
                        Content = w.Content,
                        Difficulty = w.Difficulty.ToString(),
                        Image = w.Image,
                        Point = w.Point,
                        IsPublished = w.IsPublished,
                        IsFinished = w.UserWrites.Any(uw => uw.UserId == userId && uw.IsCompleted)
                    }).OrderBy(w => w.Difficulty).ToList()
                });
            return grouped;
        }
    }
}
