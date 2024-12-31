using AutoMapper;
using Ticketier.BL.Features.DTOs;
using Ticketier.Core.Entities;

namespace Ticketier.BL.Features.Mapping.TicketMapping
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto, Ticket>();
        }
    }
}
