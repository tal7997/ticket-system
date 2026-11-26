using Microsoft.EntityFrameworkCore;
using TicketSystem.Api.Data;
using TicketSystem.Api.DTOs;
using TicketSystem.Api.Models;

namespace TicketSystem.Api.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _db;

        public TicketService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TicketDto> CreateAsync(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                Title = dto.Title.Trim(),
                Description = dto.Description.Trim(),
                Urgency = dto.Urgency
            };

            _db.Tickets.Add(ticket);
            await _db.SaveChangesAsync();

            return ToDto(ticket);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _db.Tickets.FindAsync(id);
            if (ticket == null)
                return false;

            _db.Tickets.Remove(ticket);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<List<TicketDto>> GetAllAsync(TicketStatus? status, TicketUrgency? urgency)
        {
            var query = _db.Tickets.AsQueryable();

            if(status.HasValue)
                query = query.Where(t => t.Status == status.Value);

            if(urgency.HasValue)
                query = query.Where(t => t.Urgency == urgency.Value);

            return await query
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => ToDto(t))
                .ToListAsync();
        }

        public async Task<TicketDto?> UpdateStatusAsync(int id, TicketStatus status)
        {
            var ticket = await _db.Tickets.FindAsync(id);
            if (ticket == null)
                return null;

            ticket.Status = status;
            await _db.SaveChangesAsync();

            return ToDto(ticket);
        }

        private static TicketDto ToDto(Ticket t) => new TicketDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Urgency = t.Urgency,
            Status = t.Status,
            CreatedAt = t.CreatedAt
        };
    }
}
