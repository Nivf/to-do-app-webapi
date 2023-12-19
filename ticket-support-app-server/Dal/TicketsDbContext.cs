using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Ticket_support_app_server.Models;

namespace Ticket_support_app_server.Dal
{
    public class TicketsDbContext : DbContext

    {
        public TicketsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
          .Property(b => b.Id)
          .IsRequired();
        }
        #endregion

    }
}
