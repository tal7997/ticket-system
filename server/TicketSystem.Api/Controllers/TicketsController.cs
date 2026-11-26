using Microsoft.AspNetCore.Mvc;
using TicketSystem.Api.DTOs;
using TicketSystem.Api.Models;
using TicketSystem.Api.Services;

namespace TicketSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        // GET api/tickets?status=Open&urgency=High
        [HttpGet]
        public async Task<ActionResult<List<TicketDto>>> GetAll([FromQuery] TicketStatus? status, [FromQuery] TicketUrgency? urgency)
        {
            var tickets = await _service.GetAllAsync(status, urgency);
            return Ok(tickets);
        }

        // POST api/tickets
        [HttpPost]
        public async Task<ActionResult<TicketDto>> Create(CreateTicketDto dto)
        {
            var ticket = await _service.CreateAsync(dto);
            return Created($"/api/tickets/{ticket.Id}", ticket);
        }

        // PATCH api/tickets/5/status
        [HttpPatch("{id}/status")]
        public async Task<ActionResult<TicketDto>> UpdateStatus(int id, UpdateTicketStatusDto dto)
        {
            var ticket = await _service.UpdateStatusAsync(id, dto.Status);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        // DELETE api/tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if(!deleted)
                return NotFound();

            return NoContent();
        }


    }
}
