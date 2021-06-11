using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YES.Server.Data.Entities;
using YES.Server.Enums;

namespace YES.Server.Data.Database
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
                new Address { Id = 2, Street = "Tentoonstellingslaan", StreetNumber = 1, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 1 },
                new Address { Id = 3, Street = "Leeuwstraat", StreetNumber = 7, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 2 },
                new Address { Id = 4, Street = "Zebrastraat", StreetNumber = 36, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 3 },
                new Address { Id = 5, Street = "Tijgerstraat", StreetNumber = 24, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 4 },
                new Address { Id = 6, Street = "Olifantstraat", StreetNumber = 79, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 5 }

                );
            });
        }

        private static void SeedEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(x =>
            {
                x.HasData(
                new Event { Id = 1, TicketProviderId = 1, VenueId = 1 },
                new Event { Id = 2, TicketProviderId = 1, VenueId = 1 },
                new Event { Id = 3, TicketProviderId = 1, VenueId = 1 },
                new Event { Id = 4, TicketProviderId = 1, VenueId = 1, Status = Status.Postponed }
                );
            });
        }

        private static void SeedEventInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventInfo>(x =>
            {
                x.HasData(
                new EventInfo { Id = 1, EventId = 1, Name = "EK België-Rusland", Description = "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm" },
                new EventInfo { Id = 2, EventId = 2, Name = "EK België-Denemarken", Description = "Uitzending EK wedstrijd tussen België en Denemarken, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("18/06/2021 18:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500 },
                new EventInfo { Id = 3, EventId = 3, Name = "EK België-Finland", Description = "Uitzending EK wedstrijd tussen België en Finland, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("21/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500 },
                new EventInfo { Id = 4, EventId = 4, Name = "UITGESTELD: Terras Sessie: Joni Sheila", Description = "Wees er tijdig bij want door corona zijn de plaatsen beperkt", MaxAvailableTickets = 50, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg" }
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
                new Ticket { Id = 4, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 5, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 6, EventId = 1, TicketCustomerId = 2, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 7, EventId = 1, TicketCustomerId = 2, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 8, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 9, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 10, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 11, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 12, EventId = 1, TicketCustomerId = 4, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 13, EventId = 1, TicketCustomerId = 4, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 14, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 15, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.Now },
                new Ticket { Id = 16, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.Now }
                );
            });
        }

        private static void SeedTicketPrices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketPrice>(x =>
            {
                x.HasData(
                new TicketPrice { Id = 1, Category = "zitplaats", Price = 1, TicketId = 1 },
                new TicketPrice { Id = 2, Category = "zitplaats", Price = 1, TicketId = 2 },
                new TicketPrice { Id = 3, Category = "zitplaats", Price = 1, TicketId = 3 },
                new TicketPrice { Id = 4, Category = "zitplaats", Price = 1, TicketId = 4 },
                new TicketPrice { Id = 5, Category = "zitplaats", Price = 1, TicketId = 5 },
                new TicketPrice { Id = 6, Category = "zitplaats", Price = 1, TicketId = 6 },
                new TicketPrice { Id = 7, Category = "zitplaats", Price = 1, TicketId = 7 },
                new TicketPrice { Id = 8, Category = "zitplaats", Price = 1, TicketId = 8 },
                new TicketPrice { Id = 9, Category = "zitplaats", Price = 1, TicketId = 9 },
                new TicketPrice { Id = 10, Category = "zitplaats", Price = 1, TicketId = 10 },
                new TicketPrice { Id = 11, Category = "zitplaats", Price = 1, TicketId = 11 },
                new TicketPrice { Id = 12, Category = "zitplaats", Price = 1, TicketId = 12 },
                new TicketPrice { Id = 13, Category = "zitplaats", Price = 1, TicketId = 13 },
                new TicketPrice { Id = 14, Category = "zitplaats", Price = 1, TicketId = 14 },
                new TicketPrice { Id = 15, Category = "zitplaats", Price = 1, TicketId = 15 },
                new TicketPrice { Id = 16, Category = "zitplaats", Price = 1, TicketId = 16 }
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
                new TicketCustomer { Id = 1, FirstName = "Kobe", LastName = "Delobelle", PhoneNumber = "0473 288 888", Email = "kobe@mail.com", BankAccount = "BE68 5390 0754 7034" },
                new TicketCustomer { Id = 2, FirstName = "Ward", LastName = "Impe", PhoneNumber = "0473 422 458", Email = "ward@mail.com", BankAccount = "BE68 6990 5800 7574" },
                new TicketCustomer { Id = 3, FirstName = "Pieter", LastName = "Corp", PhoneNumber = "0453 288 888", Email = "Pieter@mail.com", BankAccount = "BE60 5590 0994 7021" },
                new TicketCustomer { Id = 4, FirstName = "Seba", LastName = "Stiaan", PhoneNumber = "0485 345 349", Email = "Seba@mail.com", BankAccount = "BE70 5560 1278 7078" },
                new TicketCustomer { Id = 5, FirstName = "Nick", LastName = "Angularlover", PhoneNumber = "0478 365 852", Email = "Nick@mail.com", BankAccount = "BE77 7893 0824 7304" }
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