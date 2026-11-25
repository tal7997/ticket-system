using Microsoft.EntityFrameworkCore;
using TicketSystem.Api.Models;

namespace TicketSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; } 
    }
}
