using System;
using System.ComponentModel.DataAnnotations;

namespace ComplaintFeedbackAPI.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }  

        [Required]
        [StringLength(500)]
        public string Description { get; set; }  

        [Required]
        [StringLength(50)]
        public string Category { get; set; }  

        [Required]
        [StringLength(100)]
        public string CitizenName { get; set; }  

        [EmailAddress]
        public string CitizenEmail { get; set; }  

        [Phone]
        public string CitizenPhone { get; set; }  

        [StringLength(20)]
        public string Status { get; set; } = "Në pritje";  

        public DateTime SubmittedAt { get; set; } = DateTime.Now;  

        public string? Feedback { get; set; }  
    }
}
