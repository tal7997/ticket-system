using System.ComponentModel.DataAnnotations;
using TicketSystem.Api.Models;

namespace TicketSystem.Api.DTOs
{
    public class UpdateTicketStatusDto
    {
        [EnumDataType(typeof(TicketStatus))]
        public TicketStatus Status { get; set; }
    }
}
