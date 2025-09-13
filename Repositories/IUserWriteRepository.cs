using Learn_Net.Models;

namespace Learn_Net.Repositories
{
    public interface IUserWriteRepository
    {
        Task<UserWrite> GetAsync(int userId, int writeId);
        Task AddAsync(UserWrite userWrite);
        Task SaveChangesAsync();
    }
}
