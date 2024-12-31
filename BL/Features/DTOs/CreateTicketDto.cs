using Ticketier.Core.Enums;

namespace Ticketier.BL.Features.DTOs
{
    public class CreateTicketDto
    {
        public string PassengerName { get; set; }
        public string PassengerSSN { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        public Class Class { get; set; }

    }
}
