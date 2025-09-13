using Learn_Net.DTOs;
using Learn_Net.Models;
using Learn_Net.Repositories;

namespace Learn_Net.Services
{
    public class UserWriteService: IUserWriteService
    {
        private readonly IUserWriteRepository _repo;
        public UserWriteService(IUserWriteRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserWrite> SubmitAsync(SubmitWriteRequest request)
        {
            var existing = await _repo.GetAsync(request.UserId, request.WriteId);

            if (existing != null)
            {
                existing.TranslatedContent = request.TranslatedContent;
                existing.Score = request.Score;
                existing.IsCompleted = true;
                existing.CompletedAt = DateTime.UtcNow;
                existing.AttemptCount += 1;
            }
            else
            {
                existing = new UserWrite
                {
                    UserId = request.UserId,
                    WriteId = request.WriteId,
                    TranslatedContent = request.TranslatedContent,
                    Score = request.Score,
                    IsCompleted = true,
                    CompletedAt = DateTime.UtcNow
                };
                await _repo.AddAsync(existing);
            }
            await _repo.SaveChangesAsync();
            return existing;
        }
    }
}
