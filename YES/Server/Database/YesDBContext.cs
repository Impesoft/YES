using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YES.Server.Entities;

namespace YES.Server
{
    public class YesDBContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketProvider> TicketProviders { get; set; }
        public DbSet<TicketCustomer> TicketCustomers { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventInfo> EventInfo { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public YesDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilder.Seed();
        }
    }
}