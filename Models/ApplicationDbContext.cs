using Microsoft.EntityFrameworkCore;

namespace ComplaintFeedbackAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintFeedback> ComplaintFeedbacks { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }


    }
}
