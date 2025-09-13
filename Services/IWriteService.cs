using Learn_Net.DTOs;
using Learn_Net.Enums;
using Learn_Net.Models;

namespace Learn_Net.Services
{
    public interface IWriteService
    {
        Task<Write> CreateAsync(
           string title,
           string content,
           DifficultyLevel difficulty = DifficultyLevel.Easy,   
           WriteCategory category = WriteCategory.Other,  
           string? image = null,                       
           int point = 0,                                   
           bool isPublished = true                       
       );

       Task<IEnumerable<WriteDto>> GetAllAsync();
       Task<IEnumerable<CategoryWithWritesDto>> GetGroupedByCategoryAsync(int userId);
    }
}
