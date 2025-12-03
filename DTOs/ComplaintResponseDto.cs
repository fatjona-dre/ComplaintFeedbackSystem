namespace ComplaintFeedbackAPI.DTOs
{
    public class ComplaintResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string CitizenName { get; set; } = string.Empty;

        public string? CitizenEmail { get; set; }
        public string? CitizenPhone { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; }

        public string? Feedback { get; set; }
    }
}
