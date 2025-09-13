namespace Learn_Net.DTOs
{
    public class UserWriteDto
    {
        public int UserId { get; set; }
        public int Score { get; set; }

        public int AttemptCount { get; set; }
        public bool IsCompleted { get; set; }
    }
}
