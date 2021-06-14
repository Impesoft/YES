using Microsoft.EntityFrameworkCore;
using YES.Server.Data.Entities;

namespace YES.Server.Data.Database
{
    public class YesDBContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketProvider> TicketProviders { get; set; }
        public DbSet<TicketCustomer> TicketCustomers { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventInfo> EventInfo { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public YesDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            modelBuilder.Entity<Ticket>()
                        .HasOne(x => x.TicketCategory)
                        .WithMany(x => x.Tickets)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}