using System;
using System.ComponentModel.DataAnnotations;

namespace ComplaintFeedbackAPI.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Action { get; set; }  

        public int? ComplaintId { get; set; } 

        public string? UserId { get; set; }   

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string? Details { get; set; } 
    }
}
