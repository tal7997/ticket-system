using System.ComponentModel.DataAnnotations;
using TicketSystem.Api.Models;

namespace TicketSystem.Api.DTOs
{
	public class CreateTicketDto
	{
		[Required]
		public string Title { get; set; } = "";
		
		[Required]
		public string Description { get; set; } = "";

        [EnumDataType(typeof(TicketUrgency))]
        public TicketUrgency Urgency { get; set; } = TicketUrgency.Medium;

	}
}