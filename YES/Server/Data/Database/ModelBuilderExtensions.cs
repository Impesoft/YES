using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YES.Server.Entities;
using YES.Server.Enums;

namespace YES.Server.Database
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedVenues(modelBuilder);
            SeedTicketProviders(modelBuilder);
            SeedTicketCustomers(modelBuilder);
            SeedAddresses(modelBuilder);
            SeedEvents(modelBuilder);
            SeedEventInfo(modelBuilder);
            SeedTickets(modelBuilder);
            SeedTicketPrices(modelBuilder);
        }

        private static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(x =>
            {
                x.HasData(
                new Address { Id = 1, Street = "Sint-Pietersnieuwstraat", StreetNumber = 23, PostalCode = "9000", City = "Gent", Country = "België", TicketProviderId = 1, VenueId = 1 },
                new Address { Id = 2, Street = "Tentoonstellingslaan", StreetNumber = 1, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 1 }

                );
            });
        }

        private static void SeedEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(x =>
            {
                x.HasData(
                new Event { Id = 1, TicketProviderId = 1, VenueId = 1 },
                new Event { Id = 2, TicketProviderId = 1, VenueId = 2, Status = Status.Postponed }
                );
            });
        }

        private static void SeedEventInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventInfo>(x =>
            {
                x.HasData(
                new EventInfo { Id = 1, EventId = 1, Name = "EK België-Rusland", Description = "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm" }
                );
            });
        }

        private static void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(x =>
            {
                x.HasData(
                new Ticket { Id = 1, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 2, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 3, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 4, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.Now }
                );
            });
        }

        private static void SeedTicketProviders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketProvider>(x =>
            {
                x.HasData(
                new TicketProvider { Id = 1, NameProvider = "Vooruit", PhoneNumber = "09 267 28 20", Email = "info@vooruit.be", BankAccount = "BE78 3590 0754 7674" }
                );
            });
        }

        private static void SeedTicketCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketCustomer>(x =>
            {
                x.HasData(
                new TicketCustomer { Id = 1, FirstName = "Kobe", LastName = "Delobelle", PhoneNumber = "0473 288 888", Email = "kobe@mail.com", BankAccount = "BE68 5390 0754 7034", }
                );
            });
        }

        private static void SeedTicketPrices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketPrice>(x =>
            {
                x.HasData(
                new TicketPrice { Id = 1, Category = "zitplaats", Price = 1, TicketId = 1 }
                );
            });
        }

        private static void SeedVenues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venue>(x =>
            {
                x.HasData(
                new Venue { Id = 1, Name = "Kunstencentrum Vooruit", Capacity = 1200 }
                );
            });
        }
    }
}