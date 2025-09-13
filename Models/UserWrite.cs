namespace Learn_Net.Models
{
    public class UserWrite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int WriteId { get; set; }
        public Write Write { get; set; }

        public int Score { get; set; } = 0;
        public string TranslatedContent { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CompletedAt { get; set; }

        public int AttemptCount { get; set; } = 1;

    }
}
