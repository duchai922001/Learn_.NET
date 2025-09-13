using Learn_Net.Enums;

namespace Learn_Net.DTOs
{
    public class WriteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Point { get; set; }
        public bool IsPublished { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public WriteCategory Category { get; set; }
        public string Image { get; set; }

        public IEnumerable<UserWriteDto> UserWrites { get; set; } = new List<UserWriteDto>();
    }
}
