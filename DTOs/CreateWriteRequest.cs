using Learn_Net.Enums;
using System.ComponentModel.DataAnnotations;

namespace Learn_Net.DTOs
{
    public class CreateWriteRequest
    {
        [Required]
        [MaxLength(300)]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Easy;

        public WriteCategory Category { get; set; } = WriteCategory.Other;

        public string? Image { get; set; } 

        public int Point { get; set; } = 0;

        public bool IsPublished { get; set; } = true;
    }
}
