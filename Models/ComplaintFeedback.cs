using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintFeedbackAPI.Models
{
    public class ComplaintFeedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int? OrderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = "Complaint"; 

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
