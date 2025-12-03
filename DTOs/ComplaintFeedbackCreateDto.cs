using System.ComponentModel.DataAnnotations;

namespace YourProject.DTOs
{
    public class ComplaintFeedbackCreateDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int? OrderId { get; set; } 

        [Required]
        [StringLength(100)]
        public string Type { get; set; } 

        [Required]
        [StringLength(500)]
        public string Message { get; set; }
    }
}
