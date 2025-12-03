using Microsoft.AspNetCore.Mvc;
using ComplaintFeedbackAPI.Models;
using ComplaintFeedbackAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using YourProject.DTOs;

namespace ComplaintFeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintFeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComplaintFeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplaintFeedbackResponseDto>>> GetAll(
            [FromQuery] string? status,
            [FromQuery] string? type,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.ComplaintFeedbacks.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(c => c.Status == status);
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.Type == type);
            }

            var totalItems = await query.CountAsync();

            var complaints = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ComplaintFeedbackResponseDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    OrderId = c.OrderId,
                    Type = c.Type,
                    Message = c.Message,
                    Status = c.Status,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();

            var response = new
            {
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize,
                Complaints = complaints
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ComplaintFeedbackResponseDto>> CreateComplaint([FromBody] ComplaintFeedbackCreateDto dto)
        {

            var complaint = new ComplaintFeedback
            {
                UserId = dto.UserId,
                OrderId = dto.OrderId,
                Type = dto.Type,
                Message = dto.Message,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.ComplaintFeedbacks.Add(complaint);
            await _context.SaveChangesAsync();

            _context.AuditLogs.Add(new AuditLog
            {
                Action = "Created Complaint",
                ComplaintId = complaint.Id,
                UserId = dto.UserId,
                Details = $"Type: {complaint.Type}, Message: {complaint.Message}"
            });
            await _context.SaveChangesAsync();


            var response = new ComplaintFeedbackResponseDto
            {
                Id = complaint.Id,
                UserId = complaint.UserId,
                OrderId = complaint.OrderId,
                Type = complaint.Type,
                Message = complaint.Message,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                UpdatedAt = complaint.UpdatedAt
            };

            return CreatedAtAction(nameof(GetAll), new { id = complaint.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ComplaintFeedbackResponseDto>> UpdateComplaint(int id, [FromBody] ComplaintFeedbackResponseDto dto)
        {
            var complaint = await _context.ComplaintFeedbacks.FindAsync(id);

            if (complaint == null)
            {
                return NotFound(new { message = $"Complaint with ID {id} not found." });
            }

            complaint.Status = dto.Status ?? complaint.Status;
            complaint.Message = dto.Message ?? complaint.Message;
            complaint.UpdatedAt = DateTime.UtcNow;

            _context.ComplaintFeedbacks.Update(complaint);
            await _context.SaveChangesAsync();
            _context.AuditLogs.Add(new AuditLog
            {
                Action = "Updated Complaint",
                ComplaintId = complaint.Id,
                UserId = dto.UserId, 
                Details = $"Status changed to: {complaint.Status}, Message: {complaint.Message}"
            });
            await _context.SaveChangesAsync();


            var response = new ComplaintFeedbackResponseDto
            {
                Id = complaint.Id,
                UserId = complaint.UserId,
                OrderId = complaint.OrderId,
                Type = complaint.Type,
                Message = complaint.Message,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                UpdatedAt = complaint.UpdatedAt
            };

            return Ok(response);
        }
    }
}
