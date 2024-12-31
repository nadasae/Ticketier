
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using Ticketier.BL.Features.DTOs;
using Ticketier.BL.Interfaces;
using Ticketier.Core.Context;
using Ticketier.Core.Entities;
using Ticketier.Core.Enums;

namespace Ticketier.BL.AppServices
{
    public class TicketServices : ITicketServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TicketServices(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Crud
        //Create
        public async Task<(bool IsSuccess, string Message)> Create(CreateTicketDto _Ticket)
        {
            if (_Ticket == null)
            {
                throw new ArgumentNullException(nameof(_Ticket), "Ticket data cannot be null.");
                //return (false, "Ticket title cannot be null or empty.");
            }
            var newTicket = new Ticket();
            _mapper.Map(_Ticket, newTicket);
            await _context.AddAsync(newTicket);
            await _context.SaveChangesAsync();
            return (true, "Ticket created successfully.");
        }
        //Get All 
        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            var Tickets = await _context.Tickets.ToListAsync();
            return Tickets;
        }
        //Get By Id
        public async Task<Ticket> GetById(int Id)
        {
            var Ticket = await _context.Tickets.FirstOrDefaultAsync(t=>t.Id==Id);
            if (Ticket == null)
            {
                throw new ArgumentNullException(nameof(Ticket), "Ticket not found");
            }
            return Ticket;
        }
        //Update
        public async Task<Ticket> UpdateTicket(int Id ,UpdateTicketDto _Ticket)
        {
            var Ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);
            if (Ticket == null)
            {
                throw new ArgumentNullException(nameof(Ticket), "Ticket not found");
            }
            _mapper.Map(_Ticket,Ticket);
            Ticket.UpdatedDate = DateTime.Now;
             await _context.SaveChangesAsync();
            return Ticket;
        }
        //Delete 
        public async Task<int> DeleteTicket(int Id)
        {
            var Ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);
            if (Ticket == null)
            {
                throw new ArgumentNullException(nameof(Ticket), "Ticket not found");
            }
            _context.Tickets.Remove(Ticket);
            await _context.SaveChangesAsync();
            return Ticket.Id;
        }
    }
}
