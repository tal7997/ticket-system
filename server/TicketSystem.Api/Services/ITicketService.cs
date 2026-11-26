using TicketSystem.Api.DTOs;
using TicketSystem.Api.Models;

namespace TicketSystem.Api.Services
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetAllAsync(TicketStatus? status, TicketUrgency? urgency);
        Task<TicketDto> CreateAsync(CreateTicketDto dto);
        Task<TicketDto?> UpdateStatusAsync(int id, TicketStatus status);
        Task<bool> DeleteAsync(int id);
    }
}
