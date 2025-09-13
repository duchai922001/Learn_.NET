using Learn_Net.Enums;

namespace Learn_Net.DTOs
{
    public class CategoryWithWritesDto
    {
        public string Category { get; set; } = "";
        public List<WriteDtoByUser> Writes { get; set; } = new();
    }

    public class WriteDtoByUser
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Difficulty { get; set; } = "";
        public string Image { get; set; }
        public int Point { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFinished { get; set; }
    }

}
