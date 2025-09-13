namespace Learn_Net.DTOs
{
    public class SubmitWriteRequest
    {
        public int UserId { get; set; }
        public int WriteId { get; set; }
        public string TranslatedContent { get; set; }
        public int Score { get; set; } = 0;
    }
}
