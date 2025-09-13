using Learn_Net.DTOs;
using Learn_Net.Models;

namespace Learn_Net.Repositories
{
    public interface IWriteRepository
    {
        Task AddAsync(Write write);
        Task SaveChangesAsync();

        Task<IEnumerable<WriteDto>> GetAllAsync();

        Task<List<Write>> GetAllWithUserWritesAsync();
    }
}
