using Ticketier.BL.Features.DTOs;
using Ticketier.Core.Entities;

namespace Ticketier.BL.Interfaces
{
    public interface ITicketServices
    {
        Task<(bool IsSuccess, string Message)> Create(CreateTicketDto ticketDto);

        // Retrieve all tickets
        Task<IEnumerable<Ticket>> GetAllAsync();

        // Retrieve a specific ticket by ID
        Task<Ticket> GetById(int id);

        // Update an existing ticket
        Task<Ticket> UpdateTicket(int id, UpdateTicketDto ticketDto);

        // Delete a ticket by ID
        Task<int> DeleteTicket(int id);
    }
}
