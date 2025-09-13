using Learn_Net.Enums;

namespace Learn_Net.DTOs
{
    public class WriteResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DifficultyLevel Difficulty { get; set; }
        public WriteCategory Category { get; set; }
        public string? Image { get; set; }
        public int Point { get; set; }
        public bool IsPublished { get; set; }
    }
}
