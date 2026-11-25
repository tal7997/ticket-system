using TicketSystem.Api.Models;

namespace TicketSystem.Api.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public TicketUrgency Urgency { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
