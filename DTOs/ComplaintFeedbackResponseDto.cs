namespace YourProject.DTOs
{
    public class ComplaintFeedbackResponseDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? OrderId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
