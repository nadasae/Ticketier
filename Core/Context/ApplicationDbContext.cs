using Microsoft.EntityFrameworkCore;
using Ticketier.Core.Entities;

namespace Ticketier.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //DbSets for tables 
        public DbSet<Ticket> Tickets { get; set; }
    }
}
