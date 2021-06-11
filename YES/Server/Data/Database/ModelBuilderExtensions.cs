﻿using System;
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
                new Address { Id = 6, Street = "Apostelstraat", StreetNumber = 79, PostalCode = "9100", City = "Sint-Niklaas", Country = "België", TicketCustomerId = 5 },
                new Address { Id = 7, Street = "Olifantstraat", StreetNumber = 26, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 6 },
                new Address { Id = 8, Street = "Olifantstraat", StreetNumber = 2, PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 7 },
                new Address { Id = 9, Street = "Kleine Dalstraat", StreetNumber = 1, PostalCode = "1210", City = "Sint-Joost-ten-Node", Country = "België", TicketCustomerId = 8 },
                new Address { Id = 11, Street = "Waversesteenweg", StreetNumber = 100, PostalCode = "1040", City = "Etterbeek", Country = "België", TicketCustomerId = 9 },
                new Address { Id = 12, Street = "Rue de la Cure", StreetNumber = 3, PostalCode = "1300", City = "Waver", Country = "België", TicketCustomerId = 10 },
                new Address { Id = 13, Street = "Spuibeekstraat", StreetNumber = 4, PostalCode = "2800", City = "Mechelen", Country = "België", TicketCustomerId = 11 },
                new Address { Id = 14, Street = "Beukheuvel", StreetNumber = 20, PostalCode = "2570", City = "Duffel", Country = "België", TicketCustomerId = 12 },
                new Address { Id = 15, Street = "Nijverheidskaai", StreetNumber = 13, PostalCode = "8500", City = "Kortrijk", Country = "België", TicketCustomerId = 13 },
                new Address { Id = 16, Street = "Hondsschotestraat", StreetNumber = 83, PostalCode = "8560", City = "Wevelgem", Country = "België", TicketCustomerId = 14 },
                new Address { Id = 17, Street = "Tybaertstraat", StreetNumber = 27, PostalCode = "8900", City = "Ieper", Country = "België", TicketCustomerId = 15 },
                new Address { Id = 18, Street = "Stapelhuisstraat", StreetNumber = 17, PostalCode = "8400", City = "Oostende", Country = "België", TicketCustomerId = 16 },
                new Address { Id = 19, Street = "Graaf Van Vlaanderenplein", StreetNumber = 5, PostalCode = "9000", City = "Gent", Country = "België", VenueId = 2 },
                new Address { Id = 20, Street = "Noordersingel", StreetNumber = 28, PostalCode = "2140", City = "Antwerpen", Country = "België", VenueId = 3, TicketProviderId = 9 },
                new Address { Id = 21, Street = "Overpoortstraat", StreetNumber = 60, PostalCode = "9000", City = "Gent", Country = "België", VenueId = 4, TicketProviderId = 8 },
                new Address { Id = 22, Street = "Schijnpoortweg", StreetNumber = 119, PostalCode = "2170", City = "Antwerpen", Country = "België", VenueId = 5, TicketProviderId = 7 },
                new Address { Id = 23, Street = "Schommelei", StreetNumber = 1, PostalCode = "2850", City = "Boom", Country = "België", VenueId = 6 },
                new Address { Id = 24, Street = "Festivalpark", PostalCode = "3118", City = "Werchter", Country = "België", VenueId = 7 },
                new Address { Id = 25, Street = "Eeuwfeestlaan", StreetNumber = 617, PostalCode = "1020", City = "Brussel", Country = "België", VenueId = 8, TicketProviderId = 4 },
                new Address { Id = 26, Street = "Kempische Steenweg", PostalCode = "3500", City = "Hasselt", Country = "België", VenueId = 9 },
                new Address { Id = 27, Street = "Binnenvaartstraat", PostalCode = "3530", City = "Houthalen-Helchteren", Country = "België", VenueId = 10 },
                new Address { Id = 28, Street = "Korte Vlierstraat", StreetNumber = 6, PostalCode = "6200", City = "Antwerpen", Country = "België", TicketProviderId = 2 },
                new Address { Id = 29, Street = "Blarenberglaan", StreetNumber = 3, PostalCode = "2800", City = "Mechelen", Country = "België", TicketProviderId = 3 },
                new Address { Id = 30, Street = "Koorstraat", StreetNumber = 17, PostalCode = "3510", City = "Hasselt", Country = "België", TicketProviderId = 5 },
                new Address { Id = 31, Street = "Braziliestraat", StreetNumber = 26, PostalCode = "2000", City = "Antwerpen", Country = "België", TicketProviderId = 6 }

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
                new TicketProvider { Id = 1, NameProvider = "Vooruit", PhoneNumber = "09 267 28 20", Email = "info@vooruit.be", BankAccount = "BE78 3590 0754 7674" },
                new TicketProvider { Id = 2, NameProvider = "WAREONE.world bvba", PhoneNumber = "09 147 27 78", Email = "info@tomorrowland.be", BankAccount = "BE78 7854 3585 7820" },
                new TicketProvider { Id = 3, NameProvider = "Live Nation Festivals NV", PhoneNumber = "09 754 87 78", Email = "info@rockwerchter.be", BankAccount = "BE78 7768 3578 1220" },
                new TicketProvider { Id = 4, NameProvider = "Couleur Cafe", PhoneNumber = "09 785 24 86", Email = "info@couleurcafe.be", BankAccount = "BE76 5455 8725 7824" },
                new TicketProvider { Id = 5, NameProvider = "Chokri Mahassine", PhoneNumber = "09 765 78 86", Email = "info@pukkelpop.be", BankAccount = "BE34 8792 4687 2565" },
                new TicketProvider { Id = 6, NameProvider = "Extrema", PhoneNumber = "09 485 35 41", Email = "info@extremaoutdoor.be", BankAccount = "BE55 7865 7874 1237" },
                new TicketProvider { Id = 7, NameProvider = "Sportpaleis Group NV", PhoneNumber = "09 879 87 74", Email = "info@sportpaleisgroup.be", BankAccount = "BE78 6872 3968 7821" },
                new TicketProvider { Id = 8, NameProvider = "eLiXir", PhoneNumber = "09 782 71 42", Email = "info@elixir.be", BankAccount = "BE55 7865 7874 1237" },
                new TicketProvider { Id = 9, NameProvider = "Team Trix", PhoneNumber = "09 456 79 17", Email = "info@trix.be", BankAccount = "BE55 4752 7836 4878" }
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
                new TicketCustomer { Id = 5, FirstName = "Nick", LastName = "Angularlover", PhoneNumber = "0478 365 852", Email = "Nick@mail.com", BankAccount = "BE77 7893 0824 7304" },
                new TicketCustomer { Id = 6, FirstName = "Dries", LastName = "Maes", PhoneNumber = "0432 457 896", Email = "Dries@mail.com", BankAccount = "BE41 7563 7835 0157" },
                new TicketCustomer { Id = 7, FirstName = "Olivia", LastName = "Goossens", PhoneNumber = "0478 687 138", Email = "Olivia@mail.com", BankAccount = "BE96 4278 6420 5496" },
                new TicketCustomer { Id = 8, FirstName = "Mila", LastName = "Vandevoorde", PhoneNumber = "0485 377 352", Email = "Mila@mail.com", BankAccount = "BE77 1046 8642 5676" },
                new TicketCustomer { Id = 9, FirstName = "Alice", LastName = "Mcgregor", PhoneNumber = "0478 785 125", Email = "Alice@mail.com", BankAccount = "BE86 7831 5701 5684" },
                new TicketCustomer { Id = 10, FirstName = "Louise", LastName = "Degroote", PhoneNumber = "0477 765 782", Email = "Louise@mail.com", BankAccount = "BE68 4578 3025 7304" },
                new TicketCustomer { Id = 11, FirstName = "Mohamed", LastName = "Yilmaz", PhoneNumber = "0472 752 785", Email = "Mohamed@mail.com", BankAccount = "BE89 4785 2015 3065" },
                new TicketCustomer { Id = 12, FirstName = "Emir", LastName = "Öztürk", PhoneNumber = "0473 478 795", Email = "Emir@mail.com", BankAccount = "BE58 7520 4778 8214" },
                new TicketCustomer { Id = 13, FirstName = "Kurt", LastName = "Debolle", PhoneNumber = "0478 140 349", Email = "Kurt@mail.com", BankAccount = "BE72 0145 7857 6375" },
                new TicketCustomer { Id = 14, FirstName = "Arthur", LastName = "Vangeest", PhoneNumber = "0490 785 457", Email = "Arthur@mail.com", BankAccount = "BE86 4576 0445 4873" },
                new TicketCustomer { Id = 15, FirstName = "Noah", LastName = "Vanarke", PhoneNumber = "0475 850 852", Email = "Noah@mail.com", BankAccount = "BE69 2467 0468 0478" },
                new TicketCustomer { Id = 16, FirstName = "Victor", LastName = "De Putte", PhoneNumber = "0488 754 752", Email = "Victor@mail.com", BankAccount = "BE88 4785 9785 9620" }
                );
            });
        }

        private static void SeedVenues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venue>(x =>
            {
                x.HasData(
                new Venue { Id = 1, Name = "Kunstencentrum Vooruit", Capacity = 1110 },
                new Venue { Id = 2, Name = "Capitole Gent", Capacity = 2000 },
                new Venue { Id = 3, Name = "Trix", Capacity = 1500 },
                new Venue { Id = 4, Name = "eLiXir Dance & Night Club", Capacity = 200 },
                new Venue { Id = 5, Name = "Sportpaleis", Capacity = 23359 },
                new Venue { Id = 6, Name = "Tomorrowland", Capacity = 200000 },
                new Venue { Id = 7, Name = "Rock Werchter", Capacity = 100000 },
                new Venue { Id = 8, Name = "Couleur Café", Capacity = 60000 },
                new Venue { Id = 9, Name = "Pukkelpop", Capacity = 100000 },
                new Venue { Id = 10, Name = "Extrema Outdoor", Capacity = 60000 }
                );
            });
        }
    }
}