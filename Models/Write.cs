using Learn_Net.Enums;

namespace Learn_Net.Models
{
    public class Write
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Easy;

        public WriteCategory Category { get; set; } = WriteCategory.Other;

        public string Image { get; set; }
        public int Point { get; set; } = 0;

        public bool IsPublished { get; set; } = true;

        public ICollection<UserWrite> UserWrites { get; set; } = new List<UserWrite>();
    }
}
