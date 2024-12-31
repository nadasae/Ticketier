
using Microsoft.AspNetCore.Mvc;
using Ticketier.BL.Features.DTOs;
using Ticketier.BL.Interfaces;
using Ticketier.Core.Entities;

namespace Ticketier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;

        public TicketsController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto createTicketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _ticketServices.Create(createTicketDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _ticketServices.GetAllAsync();
            return Ok(tickets);
        }

        // GET: api/Tickets/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ticket = await _ticketServices.GetById(id);
                return Ok(ticket);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Tickets/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTicketDto updateTicketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedTicket = await _ticketServices.UpdateTicket(id, updateTicketDto);
                return Ok(updatedTicket);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/Tickets/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedTicketId = await _ticketServices.DeleteTicket(id);
                return Ok(new { Message = "Ticket deleted successfully.", TicketId = deletedTicketId });
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
