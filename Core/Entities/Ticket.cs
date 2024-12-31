using System.Security.Claims;
using Ticketier.Core.Enums;

namespace Ticketier.Core.Entities
{
    public class Ticket : Entity<int>
    {
        public string PassengerName { get; set; }
        public string PassengerSSN { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        public Class Class { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; } = DateTime.Now.AddDays(3);
    }
}
