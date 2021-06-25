using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YES.Api.Data.Entities;
using System.Security.Cryptography;
using YES.Shared.Enums;

namespace YES.Api.Data.Database
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
            SeedTicketCategories(modelBuilder);
            SeedTickets(modelBuilder);
        }

        private static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(x =>
            {
                x.HasData(
                new Address { Id = 1, Street = "Sint-Pietersnieuwstraat", StreetNumber = "23", PostalCode = "9000", City = "Gent", Country = "België", TicketProviderId = 1, VenueId = 1 },
                new Address { Id = 2, Street = "Tentoonstellingslaan", StreetNumber = "1", PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 1 },
                new Address { Id = 3, Street = "Leeuwstraat", StreetNumber = "7", PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 2 },
                new Address { Id = 4, Street = "Zebrastraat", StreetNumber = "36", PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 3 },
                new Address { Id = 5, Street = "Tijgerstraat", StreetNumber = "24", PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 4 },
                new Address { Id = 6, Street = "Apostelstraat", StreetNumber = "79", PostalCode = "9100", City = "Sint-Niklaas", Country = "België", TicketCustomerId = 5 },
                new Address { Id = 7, Street = "Olifantstraat", StreetNumber = "26", PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 6 },
                new Address { Id = 8, Street = "Olifantstraat", StreetNumber = "2", PostalCode = "9000", City = "Gent", Country = "België", TicketCustomerId = 7 },
                new Address { Id = 9, Street = "Kleine Dalstraat", StreetNumber = "1", PostalCode = "1210", City = "Sint-Joost-ten-Node", Country = "België", TicketCustomerId = 8 },
                new Address { Id = 11, Street = "Waversesteenweg", StreetNumber = "100", PostalCode = "1040", City = "Etterbeek", Country = "België", TicketCustomerId = 9 },
                new Address { Id = 12, Street = "Rue de la Cure", StreetNumber = "3", PostalCode = "1300", City = "Waver", Country = "België", TicketCustomerId = 10 },
                new Address { Id = 13, Street = "Spuibeekstraat", StreetNumber = "4", PostalCode = "2800", City = "Mechelen", Country = "België", TicketCustomerId = 11 },
                new Address { Id = 14, Street = "Beukheuvel", StreetNumber = "20", PostalCode = "2570", City = "Duffel", Country = "België", TicketCustomerId = 12 },
                new Address { Id = 15, Street = "Nijverheidskaai", StreetNumber = "13", PostalCode = "8500", City = "Kortrijk", Country = "België", TicketCustomerId = 13 },
                new Address { Id = 16, Street = "Hondsschotestraat", StreetNumber = "83", PostalCode = "8560", City = "Wevelgem", Country = "België", TicketCustomerId = 14 },
                new Address { Id = 17, Street = "Tybaertstraat", StreetNumber = "27", PostalCode = "8900", City = "Ieper", Country = "België", TicketCustomerId = 15 },
                new Address { Id = 18, Street = "Stapelhuisstraat", StreetNumber = "17", PostalCode = "8400", City = "Oostende", Country = "België", TicketCustomerId = 16 },
                new Address { Id = 19, Street = "Graaf Van Vlaanderenplein", StreetNumber = "5", PostalCode = "9000", City = "Gent", Country = "België", VenueId = 2 },
                new Address { Id = 20, Street = "Noordersingel", StreetNumber = "28", PostalCode = "2140", City = "Antwerpen", Country = "België", VenueId = 3, TicketProviderId = 9 },
                new Address { Id = 21, Street = "Overpoortstraat", StreetNumber = "60", PostalCode = "9000", City = "Gent", Country = "België", VenueId = 4, TicketProviderId = 8 },
                new Address { Id = 22, Street = "Schijnpoortweg", StreetNumber = "119A", PostalCode = "2170", City = "Antwerpen", Country = "België", VenueId = 5, TicketProviderId = 7 },
                new Address { Id = 23, Street = "Schommelei", StreetNumber = "1", PostalCode = "2850", City = "Boom", Country = "België", VenueId = 6 },
                new Address { Id = 24, Street = "Festivalpark", PostalCode = "3118", City = "Werchter", Country = "België", VenueId = 7 },
                new Address { Id = 25, Street = "Eeuwfeestlaan", StreetNumber = "617", PostalCode = "1020", City = "Brussel", Country = "België", VenueId = 8, TicketProviderId = 4 },
                new Address { Id = 26, Street = "Kempische Steenweg", PostalCode = "3500", City = "Hasselt", Country = "België", VenueId = 9 },
                new Address { Id = 27, Street = "Binnenvaartstraat", PostalCode = "3530", City = "Houthalen-Helchteren", Country = "België", VenueId = 10 },
                new Address { Id = 28, Street = "Korte Vlierstraat", StreetNumber = "6", PostalCode = "6200", City = "Antwerpen", Country = "België", TicketProviderId = 2 },
                new Address { Id = 29, Street = "Blarenberglaan", StreetNumber = "3", PostalCode = "2800", City = "Mechelen", Country = "België", TicketProviderId = 3 },
                new Address { Id = 30, Street = "Koorstraat", StreetNumber = "17", PostalCode = "3510", City = "Hasselt", Country = "België", TicketProviderId = 5 },
                new Address { Id = 31, Street = "Braziliestraat", StreetNumber = "26", PostalCode = "2000", City = "Antwerpen", Country = "België", TicketProviderId = 6 },
                new Address { Id = 32, Street = "Schijnpoortweg", StreetNumber = "119B", PostalCode = "2170", City = "Antwerpen", Country = "België", VenueId = 11 },
                new Address { Id = 33, Street = "Nieuwstad", StreetNumber = "1", PostalCode = "2000", City = "Antwerpen", Country = "België", VenueId = 12 }
                );
            });
        }

        private static void SeedEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(x =>
            {
                x.HasData(
                new Event { Id = 1, TicketProviderId = 1, VenueId = 1, Status = Status.Default },
                new Event { Id = 2, TicketProviderId = 1, VenueId = 1, Status = Status.Default },
                new Event { Id = 3, TicketProviderId = 1, VenueId = 1, Status = Status.Default },
                new Event { Id = 4, TicketProviderId = 1, VenueId = 1, Status = Status.ToBeAnnounced },
                new Event { Id = 5, TicketProviderId = 7, VenueId = 2, Status = Status.Postponed },
                new Event { Id = 6, TicketProviderId = 7, VenueId = 2, Status = Status.Postponed },
                new Event { Id = 7, TicketProviderId = 7, VenueId = 2, Status = Status.Default },
                new Event { Id = 8, TicketProviderId = 7, VenueId = 2, Status = Status.Default },
                new Event { Id = 9, TicketProviderId = 7, VenueId = 2, Status = Status.Default },
                new Event { Id = 10, TicketProviderId = 9, VenueId = 3, Status = Status.SoldOut },
                new Event { Id = 11, TicketProviderId = 9, VenueId = 3, Status = Status.Default },
                new Event { Id = 12, TicketProviderId = 9, VenueId = 3, Status = Status.Cancelled },
                new Event { Id = 13, TicketProviderId = 8, VenueId = 4, Status = Status.SoldOut },
                new Event { Id = 14, TicketProviderId = 7, VenueId = 5, Status = Status.Relocated },
                new Event { Id = 15, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed },
                new Event { Id = 16, TicketProviderId = 7, VenueId = 5, Status = Status.Cancelled },
                new Event { Id = 17, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed },
                new Event { Id = 18, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed },
                new Event { Id = 19, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed },
                new Event { Id = 20, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed },
                new Event { Id = 21, TicketProviderId = 7, VenueId = 5, Status = Status.Default },
                new Event { Id = 22, TicketProviderId = 7, VenueId = 5, Status = Status.Default },
                new Event { Id = 23, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 24, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 25, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 26, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 27, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 28, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 29, TicketProviderId = 5, VenueId = 9, Status = Status.Default },
                new Event { Id = 30, TicketProviderId = 5, VenueId = 9, Status = Status.Default },
                new Event { Id = 31, TicketProviderId = 5, VenueId = 9, Status = Status.Default },
                new Event { Id = 32, TicketProviderId = 5, VenueId = 9, Status = Status.Default },
                new Event { Id = 33, TicketProviderId = 6, VenueId = 10, Status = Status.Default },
                new Event { Id = 34, TicketProviderId = 6, VenueId = 10, Status = Status.Default },
                new Event { Id = 35, TicketProviderId = 6, VenueId = 10, Status = Status.Default },
                new Event { Id = 36, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 37, TicketProviderId = 3, VenueId = 7, Status = Status.SoldOut },
                new Event { Id = 38, TicketProviderId = 3, VenueId = 7, Status = Status.SoldOut },
                new Event { Id = 39, TicketProviderId = 3, VenueId = 7, Status = Status.SoldOut },
                new Event { Id = 40, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 41, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 42, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 43, TicketProviderId = 3, VenueId = 7, Status = Status.SoldOut },
                new Event { Id = 44, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 45, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 46, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 47, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 48, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 49, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 50, TicketProviderId = 3, VenueId = 7, Status = Status.SoldOut },
                new Event { Id = 51, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 52, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 53, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 54, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 55, TicketProviderId = 3, VenueId = 7, Status = Status.SoldOut },
                new Event { Id = 56, TicketProviderId = 3, VenueId = 7, Status = Status.Default },
                new Event { Id = 57, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 58, TicketProviderId = 7, VenueId = 11, Status = Status.Postponed },
                new Event { Id = 59, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 60, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 61, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 62, TicketProviderId = 7, VenueId = 11, Status = Status.SoldOut },
                new Event { Id = 63, TicketProviderId = 7, VenueId = 11, Status = Status.SoldOut },
                new Event { Id = 64, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 65, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 66, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 67, TicketProviderId = 7, VenueId = 11, Status = Status.Default },
                new Event { Id = 68, TicketProviderId = 7, VenueId = 12, Status = Status.Postponed },
                new Event { Id = 69, TicketProviderId = 7, VenueId = 12, Status = Status.SoldOut },
                new Event { Id = 70, TicketProviderId = 7, VenueId = 12, Status = Status.Default },
                new Event { Id = 71, TicketProviderId = 7, VenueId = 12, Status = Status.Default },
                //combi events
                new Event { Id = 72, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 73, TicketProviderId = 2, VenueId = 6, Status = Status.Default },
                new Event { Id = 74, TicketProviderId = 5, VenueId = 9, Status = Status.Default },
                new Event { Id = 75, TicketProviderId = 6, VenueId = 10, Status = Status.Default },

                //bbq
                new Event { Id = 76, TicketProviderId = 10, VenueId = 13, Status = Status.Default }

                );
            });
        }

        private static void SeedEventInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventInfo>(x =>
            {
                x.HasData(
                new EventInfo { Id = 1, EventId = 1, Name = "EK België-Rusland", Description = "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), WebsiteUrl = "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg" },
                new EventInfo { Id = 2, EventId = 2, Name = "EK België-Denemarken", Description = "Uitzending EK wedstrijd tussen België en Denemarken, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("18/06/2021 18:00:00", "dd/MM/yyyy HH:mm:ss", null), WebsiteUrl = "https://www.vooruit.be/nl/agenda/3839//EK_Denemarken_Belgie_op_groot_scherm_", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg" },
                new EventInfo { Id = 3, EventId = 3, Name = "EK België-Finland", Description = "Uitzending EK wedstrijd tussen België en Finland, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("21/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), WebsiteUrl = "https://www.vooruit.be/nl/agenda/3841//EK_Finland_Belgie_op_groot_scherm", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg" },
                new EventInfo { Id = 4, EventId = 4, Name = "Terras Sessie: Joni Sheila", Description = "Wees er tijdig bij want door corona zijn de plaatsen beperkt", WebsiteUrl = "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg" },
                new EventInfo { Id = 5, EventId = 5, Name = "Kommil Foo", EventDate = DateTime.ParseExact("18/07/2021 19:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg" },
                new EventInfo { Id = 6, EventId = 6, Name = "Kommil Foo", EventDate = DateTime.ParseExact("19/07/2021 19:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg" },
                new EventInfo { Id = 7, EventId = 7, Name = "Daniel Sloss", EventDate = DateTime.ParseExact("03/10/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De gloednieuwe, 11e solovoorstelling van de Schotse internationale comedy superster komt, vlak na zijn baanbrekende wereldsucces ‘Daniel Sloss: X’, naar Capitole Gent en Stadsschouwburg Antwerpen.", WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2021-2022/daniel-sloss", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2946/58d62f6c31062dda0be21c3983929ea88d9fb007/billboard.jpg" },
                new EventInfo { Id = 8, EventId = 8, Name = "An Evening with Alex Agnew", EventDate = DateTime.ParseExact("15/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg" },
                new EventInfo { Id = 9, EventId = 9, Name = "An Evening with Alex Agnew", EventDate = DateTime.ParseExact("16/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg" },
                new EventInfo { Id = 10, EventId = 10, Name = "Lili Grace / Rooftop Concert", EventDate = DateTime.ParseExact("24/06/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Lili Grace, dat zijn de zussen Nelle en Dienne, en zij doen ongemeen boeiende dingen met twee stemmen, cello, keyboards en electronica. Met hun dark-pop haalden ze in 2012 de finale van Humo's Rock Rally en deden ze voorprogramma's voor onder meer Trentemøller, CocoRosie en Nils Frahm.", WebsiteUrl = "https://www.trixonline.be/nl/programma/lili-grace/2756/", BannerImgUrl = "https://www.trixonline.be/images/events/detail/liligrace-web.png" },
                new EventInfo { Id = 11, EventId = 11, Name = "The Howl And The Hum", EventDate = DateTime.ParseExact("25/09/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Donkere, hypnotiserende pop uit de UK. Meng The Killers met U2 en je krijgt een soort beschrijving van hun sound (StuBru)", WebsiteUrl = "https://www.trixonline.be/nl/programma/the-howl-and-the-hum/2713/", BannerImgUrl = "https://www.trixonline.be/images/lightbox/15070028-min-scaled.jpg" },
                new EventInfo { Id = 12, EventId = 12, Name = "The Armed", EventDate = DateTime.ParseExact("18/10/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Dit concert is afgelast. Alle tickets worden automatisch terugbetaald.", WebsiteUrl = "https://www.trixonline.be/nl/programma/the-armed/2723/", BannerImgUrl = "https://www.trixonline.be/images/lightbox/the-armedall-eight.jpg" },
                new EventInfo { Id = 13, EventId = 13, Name = "VJ Ward", EventDate = DateTime.ParseExact("10/09/2021 01:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "VJ Ward in the Mix", WebsiteUrl = "https://www.facebook.com/Dj.Ward.Impe/", BannerImgUrl = "https://www.impesoft.org/images/Horizontal_logo.jpg" },
                new EventInfo { Id = 14, EventId = 14, Name = "VJ Ward / eLiXir on Tour", EventDate = DateTime.ParseExact("10/10/2021 23:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Na lang anticiperen krijgt VJ Ward een kans zich op het grote podium te bewijzen. Dit jonge talent draait overal de pannen van het dak, mis deze kans dus niet want de plaatsen zijn beperkt.", WebsiteUrl = "https://www.facebook.com/Dj.Ward.Impe/", BannerImgUrl = "https://www.impesoft.org/images/Horizontal_logo.jpg" },
                new EventInfo { Id = 15, EventId = 15, Name = "Alicia Keys: The World Tour", EventDate = DateTime.ParseExact("15/06/2021", "dd/MM/yyyy", null), Description = "Alicia Keys is terug. En hoe! Het muziekicoon met 15 GRAMMY-prijzen op haar naam kondigt vandaag haar nieuwe album ‘ALICIA’ aan met release voorzien op 20 maart bij Sony Music, en haar langverwachte terugkeer naar de podia met haar ‘ALICIA – THE WORLD TOUR’.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/alicia-keys", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/3055/2bc5d811ace73d22a3f95f204665a66dfcbfd756/billboard.jpg" },
                new EventInfo { Id = 16, EventId = 16, Name = "Iron Maiden: Legacy Of The Beast Tour", EventDate = DateTime.ParseExact("27/06/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Als gevolg van de pandemie had Iron Maiden zijn ‘Legacy of the Beast Tour 2020’ verplaatst naar juni/juli 2021. Normaal zou de band op zondag 27 juni 2021 een headlineshow spelen in het Antwerps Sportpaleis. Helaas moet de tour weer met een jaar verschoven worden. Maar niet getreurd, de band staat in 2022 opnieuw op Graspop Metal Meeting om het beste van zichzelf te geven!", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2020-2021/iron-maiden", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2813/4bd008b389321af80580493d3cb77243d46546b3/billboard.jpg" },
                new EventInfo { Id = 17, EventId = 17, Name = "The Weeknd: The After Hours Tour", EventDate = DateTime.ParseExact("28/09/2022 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg" },
                new EventInfo { Id = 18, EventId = 18, Name = "The Weeknd: The After Hours Tour", EventDate = DateTime.ParseExact("29/09/2022 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg" },
                new EventInfo { Id = 19, EventId = 19, Name = "Elton John: Farewell Yellow Brick Road Tour", EventDate = DateTime.ParseExact("16/10/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg" },
                new EventInfo { Id = 20, EventId = 20, Name = "Elton John: Farewell Yellow Brick Road Tour", EventDate = DateTime.ParseExact("17/10/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg" },
                new EventInfo { Id = 21, EventId = 21, Name = "Tomorrowland presents: Dimitri Vegas & Like Mike Garden of Madness", EventDate = DateTime.ParseExact("17/12/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Het is nú al uitkijken naar het najaar, want Tomorrowland en Dimitri Vegas & Like Mike toveren het Antwerps Sportpaleis opnieuw om tot een magisch indoorfestival. Daarvoor halen ze alles uit de kast: het beloven (voor de achtste keer al!) twee waanzinnig spectaculaire avonden te worden met de grootste hits maar ook heel wat nieuwe muziek én een vleugje Tomorrowland magie.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/tomorrowland-presents-dimitri-vegas--like-mike", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3019/71b8033e72484c9da1555c70d71d48567f708f87/banner.jpg" },
                new EventInfo { Id = 22, EventId = 22, Name = "Tomorrowland presents: Dimitri Vegas & Like Mike Garden of Madness", EventDate = DateTime.ParseExact("18/12/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Het is nú al uitkijken naar het najaar, want Tomorrowland en Dimitri Vegas & Like Mike toveren het Antwerps Sportpaleis opnieuw om tot een magisch indoorfestival. Daarvoor halen ze alles uit de kast: het beloven (voor de achtste keer al!) twee waanzinnig spectaculaire avonden te worden met de grootste hits maar ook heel wat nieuwe muziek én een vleugje Tomorrowland magie.", WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/tomorrowland-presents-dimitri-vegas--like-mike", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3019/71b8033e72484c9da1555c70d71d48567f708f87/banner.jpg" },
                new EventInfo { Id = 23, EventId = 23, Name = "Tomorrowland (Weekend 1: Day 1)", EventDate = DateTime.ParseExact("27/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 24, EventId = 24, Name = "Tomorrowland (Weekend 1: Day 2)", EventDate = DateTime.ParseExact("28/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 25, EventId = 25, Name = "Tomorrowland (Weekend 1: Day 3)", EventDate = DateTime.ParseExact("29/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 26, EventId = 26, Name = "Tomorrowland (Weekend 2: Day 1)", EventDate = DateTime.ParseExact("03/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 27, EventId = 27, Name = "Tomorrowland (Weekend 2: Day 2)", EventDate = DateTime.ParseExact("04/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 28, EventId = 28, Name = "Tomorrowland (Weekend 2: Day 3)", EventDate = DateTime.ParseExact("05/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 29, EventId = 29, Name = "Pukkelpop (Day 1)", EventDate = DateTime.ParseExact("19/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://cdn.stayhappening.com/events10/banners/9b45e1fb9b14a6a30fa89fc1e6b0583569013cebd6d69737b862f0273192446b-rimg-w526-h296-gmir.jpg?v=1621779724" },
                new EventInfo { Id = 30, EventId = 30, Name = "Pukkelpop (Day 2)", EventDate = DateTime.ParseExact("20/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://cdn.stayhappening.com/events10/banners/9b45e1fb9b14a6a30fa89fc1e6b0583569013cebd6d69737b862f0273192446b-rimg-w526-h296-gmir.jpg?v=1621779724" },
                new EventInfo { Id = 31, EventId = 31, Name = "Pukkelpop (Day 3)", EventDate = DateTime.ParseExact("21/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://cdn.stayhappening.com/events10/banners/9b45e1fb9b14a6a30fa89fc1e6b0583569013cebd6d69737b862f0273192446b-rimg-w526-h296-gmir.jpg?v=1621779724" },
                new EventInfo { Id = 32, EventId = 32, Name = "Pukkelpop (Day 4)", EventDate = DateTime.ParseExact("22/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://cdn.stayhappening.com/events10/banners/9b45e1fb9b14a6a30fa89fc1e6b0583569013cebd6d69737b862f0273192446b-rimg-w526-h296-gmir.jpg?v=1621779724" },
                new EventInfo { Id = 33, EventId = 33, Name = "Extrema Outdoor Extra: September edition (Day 1)", EventDate = DateTime.ParseExact("17/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://partyflock.nl/images/party/415369_1000x524_592192/Extrema-Outdoor.webp" },
                new EventInfo { Id = 34, EventId = 34, Name = "Extrema Outdoor Extra: September edition (Day 2)", EventDate = DateTime.ParseExact("18/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://partyflock.nl/images/party/415369_1000x524_592192/Extrema-Outdoor.webp" },
                new EventInfo { Id = 35, EventId = 35, Name = "Extrema Outdoor Extra: September edition (Day 3)", EventDate = DateTime.ParseExact("19/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://partyflock.nl/images/party/415369_1000x524_592192/Extrema-Outdoor.webp" },
                new EventInfo { Id = 36, EventId = 36, Name = "Balthazar + Sohnarr", EventDate = DateTime.ParseExact("01/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 37, EventId = 37, Name = "Goose", EventDate = DateTime.ParseExact("02/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 38, EventId = 38, Name = "Arsenal & Tin Fingers", EventDate = DateTime.ParseExact("03/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 39, EventId = 39, Name = "Lil Kleine, Ronnie Flex & The Fam", EventDate = DateTime.ParseExact("04/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 40, EventId = 40, Name = "Bazart & Yong Yello", EventDate = DateTime.ParseExact("08/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 41, EventId = 41, Name = "Gabriel Rios, Eefje De Visser & Emmy D'Arc", EventDate = DateTime.ParseExact("09/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 42, EventId = 42, Name = "Bart Peeters & De Ideale Mannen", EventDate = DateTime.ParseExact("10/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 43, EventId = 43, Name = "Tourist LeMC", EventDate = DateTime.ParseExact("11/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 44, EventId = 44, Name = "Goose & Glints", EventDate = DateTime.ParseExact("15/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 45, EventId = 45, Name = "Blackwave., Charles & Emma Bale", EventDate = DateTime.ParseExact("16/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 46, EventId = 46, Name = "De Mens & Ruben Block", EventDate = DateTime.ParseExact("17/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 47, EventId = 47, Name = "Regi Live, Cleymans & Van Geel", EventDate = DateTime.ParseExact("18/08/2021 15:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 48, EventId = 48, Name = "Jasper Steverlinck & Portland", EventDate = DateTime.ParseExact("18/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 49, EventId = 49, Name = "Alex Agnew", EventDate = DateTime.ParseExact("22/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 50, EventId = 50, Name = "Zwangere Guy, Miss Angel & Chibi Ichigo", EventDate = DateTime.ParseExact("23/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 51, EventId = 51, Name = "Whispering Sons & Millionaire", EventDate = DateTime.ParseExact("24/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 52, EventId = 52, Name = "Snelle & De Lieve Jongens Band", EventDate = DateTime.ParseExact("25/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 53, EventId = 53, Name = "Bart Peters & De Ideale Mannen", EventDate = DateTime.ParseExact("29/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 54, EventId = 54, Name = "Selah Sue, Meskerem Mees, TheColorGrey & Sam De Neef", EventDate = DateTime.ParseExact("30/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 55, EventId = 55, Name = "Niels Destadsbader", EventDate = DateTime.ParseExact("31/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 56, EventId = 56, Name = "Black Box Revelation, Brutus, Equal Idiots, Stake & KillTheLogo", EventDate = DateTime.ParseExact("01/09/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 57, EventId = 57, Name = "Camille Dhont - VUURWERK", EventDate = DateTime.ParseExact("11/09/2021 14:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Het gebeurt niet vaak dat er een nieuwe artieste opstaat waarvan iedereen onmiddellijk overtuigd is: die gaat het maken! Een eer die de Westvlaamse CAMILLE wel te beurt valt; de makers van #LikeMe gaven haar eerst een hoofdrol in hun serie, Regi vroeg haar om op één van zijn singles te zingen en niet lang daarna nam Niels William haar onder zijn vleugels en tekende ze een platencontract bij CNR Records.", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2022-2023/camille", BannerImgUrl = "https://static1.qmusic.medialaancdn.be/site/w2400/3/0f/0c/54/1483971/Screenshot_2021-06-11_at_07.03.22.png" },
                new EventInfo { Id = 58, EventId = 58, Name = "James Blunt", EventDate = DateTime.ParseExact("29/03/2022 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Voor zijn zesde album keerde James Blunt terug naar de basis, en doet hij wat hem in 2005 naar een sterrenstatus katapulteerde: het schrijven van bloedeerlijk en gevoelige songs met een rijke melodie. ‘This is the album of my life’ zegt hij zelf over ‘Once Upon A Mind’. Nooit eerder was hij zo emotioneel betrokken, hij draagt het album dan ook op aan zijn zieke vader. ‘Wanneer je beseft dat je ouders niet onsterfelijk zijn, en je zelf net vader wordt zie je de levenscyclus ineens heel duidelijk.’", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/james-blunt", BannerImgUrl = "https://www.frontview-magazine.be/sites/default/files/news/159571-nieuwe-datum-voor-james-blunt-in-lotto-arena-antwerpen-1321908.jpg" },
                new EventInfo { Id = 59, EventId = 59, Name = "De Grungblavers", EventDate = DateTime.ParseExact("04/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De Grungblavers dat zijn Guillaume Van der Stighelen, Jan Van Looveren, Paul “Boogie Boy” Ambach, Gène Bervoets, Erik Goossens, Ludovic Nyamabo, Dirk Cassiers, Marc Fransen, Stany Crets en Nathan “N8N” Ambach. De Grungblavers zingen naar hun moedertaal (zijnde “het Aantwaarps”) vertaalde evergreens en in 2020 zijn ze klaar voor groter en grootst: de Lotto Arena. Ze halen alle toeters en bellen uit de kast, zorg dat je erbij bent op dit unieke concert!", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/de-grungblavers", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2630/20ce833a5437ecf4f317c0afb2d4e19b18fad69a/banner.jpg" },
                new EventInfo { Id = 60, EventId = 60, Name = "Liefde voor Muziek LIVE", EventDate = DateTime.ParseExact("25/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "*Liefde voor Muziek – voor het eerst live op een podium met Tourist LeMC, Emma Bale, Willy Sommers, Cleymans & Van Geel, Geike Arnaert, Bert Ostyn van Absynthe Minded en Ronny Mosuse.", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/liefde-voor-muziek-live", BannerImgUrl = "https://img.static-rmg.be/a/view/q100/w720/h480/3177707/liefdevoormuziekconcert-jpg.jpg" },
                new EventInfo { Id = 61, EventId = 61, Name = "Kensington", EventDate = DateTime.ParseExact("05/11/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Het Nederlandse Kensington is in eigen land uitgegroeid tot één van de meest populaire en succesvolste bands. Tal van awards pronken op hun kast: De Popprijs 2017, 3FM Awards, MTV Awards, ‘Song Van Het Jaar 2018’ voor “Slicer”. De band is kind aan huis in de Amsterdamse Ziggo Dome met 13 uitverkochte shows, waarvan 3 in december 2019, en wist als eerste Nederlandse band ook de Johan Cruijff Arena volledig te vullen in 2018. Hun vorige album ‘Control’ (2016) was goed voor drie keer platina.", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/kensington", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2685/d12fb2470eec6533a60ea148470ba89c7c343abf/billboard.jpg" },
                new EventInfo { Id = 62, EventId = 62, Name = "André Hazes: De avond van je leven", EventDate = DateTime.ParseExact("10/11/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "André Hazes wordt door België omarmd. Wanneer ‘Leef’ klinkt, wordt het glas geheven en de daad bij het woord gevoegd. Haal net als André Hazes alles uit het leven en kom terug op 10 en 11 november 2021 feesten in de Lotto Arena! Beleef samen met vrienden, familie, collega’s een onvergetelijke avond uit!", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/andre-hazes-2020", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2043/473b45b4c412c3cc2119f26af28b2296070a32ac/billboard.jpg" },
                new EventInfo { Id = 63, EventId = 63, Name = "André Hazes: De avond van je leven", EventDate = DateTime.ParseExact("11/11/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "André Hazes wordt door België omarmd. Wanneer ‘Leef’ klinkt, wordt het glas geheven en de daad bij het woord gevoegd. Haal net als André Hazes alles uit het leven en kom terug op 10 en 11 november 2021 feesten in de Lotto Arena! Beleef samen met vrienden, familie, collega’s een onvergetelijke avond uit!", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/andre-hazes-2020", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2043/473b45b4c412c3cc2119f26af28b2296070a32ac/billboard.jpg" },
                new EventInfo { Id = 64, EventId = 64, Name = "André Hazes: De avond van je leven", EventDate = DateTime.ParseExact("13/11/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "André Hazes wordt door België omarmd. Wanneer ‘Leef’ klinkt, wordt het glas geheven en de daad bij het woord gevoegd. Haal net als André Hazes alles uit het leven en kom terug op 10 en 11 november 2021 feesten in de Lotto Arena! Beleef samen met vrienden, familie, collega’s een onvergetelijke avond uit!", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/andre-hazes-2020", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2043/473b45b4c412c3cc2119f26af28b2296070a32ac/billboard.jpg" },
                new EventInfo { Id = 65, EventId = 65, Name = "Cocô Loco", EventDate = DateTime.ParseExact("31/10/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Coco Loco is gekend voor zijn adembenemende show. Zijn buitengewone feestcombinatie tussen een magische halloween, kleurrijk carnaval & vintage circus. Een avond vol sensationele acrobaten & circusartiesten, headliner dj’s en acts, spectaculaire shows en tonnen confetti.", WebsiteUrl = "http://www.sportpaleis.be/nl/kalender/2021-2022/coco-loco", BannerImgUrl = "https://www.cocoloco-festival.be/content/img/1/1356-24711-cocoloco-festival-311021-697c0f9b70a15985.jpg" },
                new EventInfo { Id = 66, EventId = 66, Name = "Bazart", EventDate = DateTime.ParseExact("19/11/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Daar is-ie dan. De fonkelnieuwe plaat van Bazart! ‘Onderweg’ is al het derde album van de razendpopulaire band rond Mathieu Terryn, Simon Nuytten en Oliver Symons. De heren hebben er de afgelopen maanden enorm hard aan gewerkt en staan te popelen om hun nieuwe muziek nu ook live naar hun publiek te brengen. Dat doen ze deze zomer op Werchter Parklife en dit najaar op vrijdag 19 november in de Antwerpse Lotto Arena. Dat de goesting niet alleen bij Bazart erg groot is, maar ook bij hun fans, bleek uit de ticketverkoop voor beide concerten. Daarom kondigt de indiepopgroep een extra concert aan in de Lotto Arena op zaterdag 20 november.", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/bazart", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3044/98effc1370869f81c86ff90dbffa62d3c86bbe14/billboard.jpg" },
                new EventInfo { Id = 67, EventId = 67, Name = "Bazart", EventDate = DateTime.ParseExact("20/11/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Daar is-ie dan. De fonkelnieuwe plaat van Bazart! ‘Onderweg’ is al het derde album van de razendpopulaire band rond Mathieu Terryn, Simon Nuytten en Oliver Symons. De heren hebben er de afgelopen maanden enorm hard aan gewerkt en staan te popelen om hun nieuwe muziek nu ook live naar hun publiek te brengen. Dat doen ze deze zomer op Werchter Parklife en dit najaar op vrijdag 19 november in de Antwerpse Lotto Arena. Dat de goesting niet alleen bij Bazart erg groot is, maar ook bij hun fans, bleek uit de ticketverkoop voor beide concerten. Daarom kondigt de indiepopgroep een extra concert aan in de Lotto Arena op zaterdag 20 november.", WebsiteUrl = "http://www.lotto-arena.be/nl/kalender/2021-2022/bazart", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3044/98effc1370869f81c86ff90dbffa62d3c86bbe14/billboard.jpg" },
                new EventInfo { Id = 68, EventId = 68, Name = "Isabelle Beernaert | Naakt", EventDate = DateTime.ParseExact("25/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Isabelle Beernaert presenteert ‘Naakt’. Puur, eerlijk, transparant, rauw. ", WebsiteUrl = "http://www.stadsschouwburg-antwerpen.be/nl/kalender/2020-2021/isabelle-beernaert", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2780/551dc1281881e14ed7d2ca3ef5ceb6ec8a425e79/billboard.jpg" },
                new EventInfo { Id = 69, EventId = 69, Name = "An Evening with Alex Agnew", EventDate = DateTime.ParseExact("10/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", WebsiteUrl = "http://www.stadsschouwburg-antwerpen.be/nl/kalender/2021-2022/an-evening-with-alex-agnew", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg" },
                new EventInfo { Id = 70, EventId = 70, Name = "An Evening with Alex Agnew", EventDate = DateTime.ParseExact("11/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", WebsiteUrl = "http://www.stadsschouwburg-antwerpen.be/nl/kalender/2021-2022/an-evening-with-alex-agnew", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg" },
                new EventInfo { Id = 71, EventId = 71, Name = "Jimmy Carr: Terribly Fun", EventDate = DateTime.ParseExact("16/09/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Jimmy vertelt in zijn gloednieuwe show grappen over allerlei verschrikkelijke zaken. Verschrikkelijke zaken waar jij of één van je geliefden misschien mee te maken kreeg. Maar het zijn gewoon grappen – het zijn niet de verschrikkelijke zaken zelf. Politieke correctheid bij een comedy show is zoals gezondheid en veiligheid bij een rodeo.", WebsiteUrl = "http://www.stadsschouwburg-antwerpen.be/nl/kalender/2021-2022/jimmy-carr", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3006/1b4955c85eaba8fb2989dbd498acda51b7530e85/billboard.jpg" },
                new EventInfo { Id = 72, EventId = 72, Name = "Tomorrowland (Weekend 1)", EventDate = DateTime.ParseExact("27/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Tomorrowland Full Madness: Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 73, EventId = 73, Name = "Tomorrowland (Weekend 2)", EventDate = DateTime.ParseExact("03/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Tomorrowland Full Madness: Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 74, EventId = 74, Name = "Pukkelpop (combi)", EventDate = DateTime.ParseExact("19/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://cdn.stayhappening.com/events10/banners/9b45e1fb9b14a6a30fa89fc1e6b0583569013cebd6d69737b862f0273192446b-rimg-w526-h296-gmir.jpg?v=1621779724" },
                new EventInfo { Id = 75, EventId = 75, Name = "Extrema Outdoor Extra: September edition (full)", EventDate = DateTime.ParseExact("17/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://partyflock.nl/images/party/415369_1000x524_592192/Extrema-Outdoor.webp" },
                new EventInfo { Id = 76, EventId = 76, Name = "BBQ chez Nique", EventDate = DateTime.ParseExact("04/07/2021 18:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Een BBQ in het uiterst gezellige dorpje Sint-Niklaas, met als mysterieuze gastheer Nick Angularlover, met muziek verzorgd door DJ Ward, vlees gebakken door Pieter Corp, groen voorzien door Marieke Vanholland en amusement met 'het grote spinning wheel-spel' gebracht door Jens Opzolder, belooft het een onvergetelijke avond te worden.", WebsiteUrl = "https://www.nivr.dev", BannerImgUrl = "https://avatars.githubusercontent.com/u/7573050?v=4" }

                );
            });
        }

        private static void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(x =>
            {
                x.HasData(
                new Ticket { Id = 1, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 2, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 3, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 4, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 5, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 6, EventId = 1, TicketCustomerId = 2, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 7, EventId = 1, TicketCustomerId = 2, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 8, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 9, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 10, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 11, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 12, EventId = 1, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 13, EventId = 1, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 14, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 15, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 16, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 1 },
                new Ticket { Id = 17, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 18, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 19, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 20, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 21, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 22, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 23, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 24, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 25, EventId = 13, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 26, EventId = 13, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 27, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 28, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 29, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 30, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 17 },
                new Ticket { Id = 31, EventId = 13, TicketCustomerId = 6, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 32, EventId = 13, TicketCustomerId = 7, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 33, EventId = 13, TicketCustomerId = 8, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 34, EventId = 13, TicketCustomerId = 8, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 35, EventId = 13, TicketCustomerId = 9, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 36, EventId = 13, TicketCustomerId = 9, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 37, EventId = 13, TicketCustomerId = 10, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 38, EventId = 13, TicketCustomerId = 11, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 39, EventId = 13, TicketCustomerId = 12, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 40, EventId = 13, TicketCustomerId = 12, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 41, EventId = 13, TicketCustomerId = 13, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 42, EventId = 13, TicketCustomerId = 13, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 43, EventId = 13, TicketCustomerId = 13, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 44, EventId = 13, TicketCustomerId = 14, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 45, EventId = 13, TicketCustomerId = 15, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 46, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 47, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 48, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 49, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 50, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 16 },
                new Ticket { Id = 51, EventId = 65, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("17/06/2021 10:13:00", "dd/MM/yyyy HH:mm:ss", null), TicketCategoryId = 150 }

                );
            });
        }

        private static void SeedTicketCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketCategory>(x =>
            {
                x.HasData(
                //vooruit
                new TicketCategory { Id = 1, Price = 1, MaxAmount = 500, EventId = 1, Name = "zitplaats tafel" },
                new TicketCategory { Id = 2, Price = 1, MaxAmount = 500, EventId = 2, Name = "zitplaats tafel" },
                new TicketCategory { Id = 3, Price = 1, MaxAmount = 500, EventId = 3, Name = "zitplaats tafel" },
                new TicketCategory { Id = 4, Price = 5, MaxAmount = 50, EventId = 4, Name = "terras" },
                //capitole
                new TicketCategory { Id = 5, Price = 28, MaxAmount = 1000, EventId = 5, Name = "regular" },
                new TicketCategory { Id = 6, Price = 28, MaxAmount = 1000, EventId = 6, Name = "regular" },
                new TicketCategory { Id = 7, Price = 36, MaxAmount = 700, EventId = 7, Name = "regular" },
                new TicketCategory { Id = 8, Price = 45, MaxAmount = 300, EventId = 7, Name = "balkon" },
                new TicketCategory { Id = 9, Price = 40, MaxAmount = 700, EventId = 8, Name = "regular" },
                new TicketCategory { Id = 10, Price = 45, MaxAmount = 300, EventId = 8, Name = "balkon" },
                new TicketCategory { Id = 11, Price = 40, MaxAmount = 700, EventId = 9, Name = "regular" },
                new TicketCategory { Id = 12, Price = 45, MaxAmount = 300, EventId = 9, Name = "balkon" },
                //trix
                new TicketCategory { Id = 13, Price = 5, MaxAmount = 50, EventId = 10, Name = "dakterras" },
                new TicketCategory { Id = 14, Price = 5, MaxAmount = 150, EventId = 11, Name = "main café" },
                new TicketCategory { Id = 15, Price = 14.5, MaxAmount = 100, EventId = 12, Name = "main café" },
                //elixir
                new TicketCategory { Id = 16, Price = 4, MaxAmount = 180, EventId = 13, Name = "regular" },
                new TicketCategory { Id = 17, Price = 7, MaxAmount = 15, EventId = 13, Name = "VIP" },
                //sportpaleis
                new TicketCategory { Id = 18, Price = 20, MaxAmount = 22000, EventId = 14, Name = "regular" },
                new TicketCategory { Id = 19, Price = 30, MaxAmount = 1000, EventId = 14, Name = "hot ticket" },
                new TicketCategory { Id = 20, Price = 55, MaxAmount = 50, EventId = 14, Name = "VIP Meet & Greet package" },
                new TicketCategory { Id = 21, Price = 75, MaxAmount = 22000, EventId = 15, Name = "regular" },
                new TicketCategory { Id = 22, Price = 149, MaxAmount = 930, EventId = 15, Name = "hot ticket" },
                new TicketCategory { Id = 23, Price = 319, MaxAmount = 100, EventId = 15, Name = "gold lounge package" },
                new TicketCategory { Id = 24, Price = 819, MaxAmount = 20, EventId = 15, Name = "VIP Meet & Greet package" },
                new TicketCategory { Id = 25, Price = 43.07, MaxAmount = 10000, EventId = 17, Name = "regular" },
                new TicketCategory { Id = 26, Price = 54.26, MaxAmount = 10000, EventId = 17, Name = "better seats" },
                new TicketCategory { Id = 27, Price = 76.66, MaxAmount = 1500, EventId = 17, Name = "hot seats" },
                new TicketCategory { Id = 28, Price = 216.66, MaxAmount = 700, EventId = 17, Name = "early entry package" },
                new TicketCategory { Id = 29, Price = 177.66, MaxAmount = 100, EventId = 17, Name = "silver hot ticket package" },
                new TicketCategory { Id = 30, Price = 227.66, MaxAmount = 100, EventId = 17, Name = "gold hot ticket package" },
                new TicketCategory { Id = 31, Price = 43.07, MaxAmount = 10000, EventId = 18, Name = "regular" },
                new TicketCategory { Id = 32, Price = 54.26, MaxAmount = 10000, EventId = 18, Name = "better seats" },
                new TicketCategory { Id = 33, Price = 76.66, MaxAmount = 1500, EventId = 18, Name = "hot seats" },
                new TicketCategory { Id = 34, Price = 216.66, MaxAmount = 700, EventId = 18, Name = "early entry package" },
                new TicketCategory { Id = 35, Price = 177.66, MaxAmount = 100, EventId = 18, Name = "silver hot ticket package" },
                new TicketCategory { Id = 36, Price = 227.66, MaxAmount = 100, EventId = 18, Name = "gold hot ticket package" },
                new TicketCategory { Id = 37, Price = 58, MaxAmount = 10000, EventId = 19, Name = "regular" },
                new TicketCategory { Id = 38, Price = 76, MaxAmount = 10000, EventId = 19, Name = "better seats" },
                new TicketCategory { Id = 39, Price = 106, MaxAmount = 1500, EventId = 19, Name = "hot seats" },
                new TicketCategory { Id = 40, Price = 215, MaxAmount = 700, EventId = 19, Name = "Tiny Dancer VIP package" },
                new TicketCategory { Id = 41, Price = 255, MaxAmount = 100, EventId = 19, Name = "Bennie and the Jets VIP package" },
                new TicketCategory { Id = 42, Price = 299, MaxAmount = 100, EventId = 19, Name = "Crocodile Rock VIP package" },
                new TicketCategory { Id = 43, Price = 349, MaxAmount = 100, EventId = 19, Name = "Rocket Man VIP package" },
                new TicketCategory { Id = 44, Price = 58, MaxAmount = 10000, EventId = 20, Name = "regular" },
                new TicketCategory { Id = 45, Price = 76, MaxAmount = 10000, EventId = 20, Name = "better seats" },
                new TicketCategory { Id = 46, Price = 106, MaxAmount = 1500, EventId = 20, Name = "hot seats" },
                new TicketCategory { Id = 47, Price = 215, MaxAmount = 700, EventId = 20, Name = "Tiny Dancer VIP package" },
                new TicketCategory { Id = 48, Price = 255, MaxAmount = 100, EventId = 20, Name = "Bennie and the Jets VIP package" },
                new TicketCategory { Id = 49, Price = 299, MaxAmount = 100, EventId = 20, Name = "Crocodile Rock VIP package" },
                new TicketCategory { Id = 50, Price = 349, MaxAmount = 100, EventId = 20, Name = "Rocket Man VIP package" },
                new TicketCategory { Id = 51, Price = 38.59, MaxAmount = 10000, EventId = 21, Name = "regular" },
                new TicketCategory { Id = 52, Price = 44.18, MaxAmount = 10000, EventId = 21, Name = "better seats" },
                new TicketCategory { Id = 53, Price = 55.38, MaxAmount = 1500, EventId = 21, Name = "hot seats" },
                new TicketCategory { Id = 54, Price = 154.50, MaxAmount = 1500, EventId = 21, Name = "early entry experience" },
                new TicketCategory { Id = 55, Price = 364, MaxAmount = 20, EventId = 21, Name = "Meet & Greet Experience - zitplaats" },
                new TicketCategory { Id = 56, Price = 374, MaxAmount = 20, EventId = 21, Name = "Meet & Greet Experience - staanplaats" },
                new TicketCategory { Id = 57, Price = 38.59, MaxAmount = 10000, EventId = 22, Name = "regular" },
                new TicketCategory { Id = 58, Price = 44.18, MaxAmount = 10000, EventId = 22, Name = "better seats" },
                new TicketCategory { Id = 59, Price = 55.38, MaxAmount = 1500, EventId = 22, Name = "hot seats" },
                new TicketCategory { Id = 60, Price = 154.50, MaxAmount = 1500, EventId = 22, Name = "early entry experience" },
                new TicketCategory { Id = 61, Price = 364, MaxAmount = 20, EventId = 22, Name = "Meet & Greet Experience - zitplaats" },
                new TicketCategory { Id = 62, Price = 374, MaxAmount = 20, EventId = 22, Name = "Meet & Greet Experience - staanplaats" },
                //tomorrowland
                new TicketCategory { Id = 63, Price = 249, MaxAmount = 50000, EventId = 72, Name = "Full Madness Pass" },
                new TicketCategory { Id = 64, Price = 440, MaxAmount = 10000, EventId = 72, Name = "Full Madness Comfort Pass" },
                new TicketCategory { Id = 65, Price = 105, MaxAmount = 80000, EventId = 23, Name = "Day Pass" },
                new TicketCategory { Id = 66, Price = 148.5, MaxAmount = 50000, EventId = 23, Name = "Pleasure Day Pass" },
                new TicketCategory { Id = 67, Price = 190, MaxAmount = 10000, EventId = 23, Name = "Comfort Day Pass" },
                new TicketCategory { Id = 68, Price = 105, MaxAmount = 80000, EventId = 24, Name = "Day Pass" },
                new TicketCategory { Id = 69, Price = 148.5, MaxAmount = 50000, EventId = 24, Name = "Pleasure Day Pass" },
                new TicketCategory { Id = 70, Price = 190, MaxAmount = 10000, EventId = 24, Name = "Comfort Day Pass" },
                new TicketCategory { Id = 71, Price = 105, MaxAmount = 80000, EventId = 25, Name = "Day Pass" },
                new TicketCategory { Id = 72, Price = 148.5, MaxAmount = 50000, EventId = 25, Name = "Pleasure Day Pass" },
                new TicketCategory { Id = 73, Price = 190, MaxAmount = 10000, EventId = 25, Name = "Comfort Day Pass" },
                new TicketCategory { Id = 74, Price = 249, MaxAmount = 50000, EventId = 73, Name = "Full Madness Pass" },
                new TicketCategory { Id = 75, Price = 440, MaxAmount = 10000, EventId = 73, Name = "Full Madness Comfort Pass" },
                new TicketCategory { Id = 76, Price = 105, MaxAmount = 80000, EventId = 26, Name = "Day Pass" },
                new TicketCategory { Id = 77, Price = 148.5, MaxAmount = 50000, EventId = 26, Name = "Pleasure Day Pass" },
                new TicketCategory { Id = 78, Price = 190, MaxAmount = 10000, EventId = 26, Name = "Comfort Day Pass" },
                new TicketCategory { Id = 79, Price = 105, MaxAmount = 80000, EventId = 27, Name = "Day Pass" },
                new TicketCategory { Id = 80, Price = 148.5, MaxAmount = 50000, EventId = 27, Name = "Pleasure Day Pass" },
                new TicketCategory { Id = 81, Price = 190, MaxAmount = 10000, EventId = 27, Name = "Comfort Day Pass" },
                new TicketCategory { Id = 82, Price = 105, MaxAmount = 80000, EventId = 28, Name = "Day Pass" },
                new TicketCategory { Id = 83, Price = 148.5, MaxAmount = 50000, EventId = 28, Name = "Pleasure Day Pass" },
                new TicketCategory { Id = 84, Price = 190, MaxAmount = 10000, EventId = 28, Name = "Comfort Day Pass" },
                //pukkelpop
                new TicketCategory { Id = 85, Price = 215, MaxAmount = 25000, EventId = 74, Name = "Combi Ticket" },
                new TicketCategory { Id = 86, Price = 105, MaxAmount = 75000, EventId = 29, Name = "Dagticket" },
                new TicketCategory { Id = 87, Price = 105, MaxAmount = 75000, EventId = 30, Name = "Dagticket" },
                new TicketCategory { Id = 88, Price = 105, MaxAmount = 75000, EventId = 31, Name = "Dagticket" },
                new TicketCategory { Id = 89, Price = 105, MaxAmount = 75000, EventId = 32, Name = "Dagticket" },
                //extrema
                new TicketCategory { Id = 90, Price = 5, MaxAmount = 25000, EventId = 75, Name = "Combi Ticket" },
                new TicketCategory { Id = 91, Price = 0, MaxAmount = 35000, EventId = 33, Name = "Dagticket" },
                new TicketCategory { Id = 92, Price = 0, MaxAmount = 35000, EventId = 34, Name = "Dagticket" },
                new TicketCategory { Id = 93, Price = 0, MaxAmount = 35000, EventId = 35, Name = "Dagticket" },
                //werchter parklife
                new TicketCategory { Id = 94, Price = 35, MaxAmount = 2500, EventId = 36, Name = "Park Ticket" },
                new TicketCategory { Id = 95, Price = 35, MaxAmount = 2500, EventId = 37, Name = "Park Ticket" },
                new TicketCategory { Id = 96, Price = 35, MaxAmount = 2500, EventId = 38, Name = "Park Ticket" },
                new TicketCategory { Id = 97, Price = 35, MaxAmount = 2500, EventId = 39, Name = "Park Ticket" },
                new TicketCategory { Id = 98, Price = 35, MaxAmount = 2500, EventId = 40, Name = "Park Ticket" },
                new TicketCategory { Id = 99, Price = 35, MaxAmount = 2500, EventId = 41, Name = "Park Ticket" },
                new TicketCategory { Id = 100, Price = 35, MaxAmount = 2500, EventId = 42, Name = "Park Ticket" },
                new TicketCategory { Id = 101, Price = 35, MaxAmount = 2500, EventId = 43, Name = "Park Ticket" },
                new TicketCategory { Id = 102, Price = 35, MaxAmount = 2500, EventId = 44, Name = "Park Ticket" },
                new TicketCategory { Id = 103, Price = 35, MaxAmount = 2500, EventId = 45, Name = "Park Ticket" },
                new TicketCategory { Id = 104, Price = 35, MaxAmount = 2500, EventId = 46, Name = "Park Ticket" },
                new TicketCategory { Id = 105, Price = 35, MaxAmount = 2500, EventId = 47, Name = "Park Ticket" },
                new TicketCategory { Id = 106, Price = 35, MaxAmount = 2500, EventId = 48, Name = "Park Ticket" },
                new TicketCategory { Id = 107, Price = 35, MaxAmount = 2500, EventId = 49, Name = "Park Ticket" },
                new TicketCategory { Id = 108, Price = 35, MaxAmount = 2500, EventId = 50, Name = "Park Ticket" },
                new TicketCategory { Id = 109, Price = 35, MaxAmount = 2500, EventId = 51, Name = "Park Ticket" },
                new TicketCategory { Id = 110, Price = 35, MaxAmount = 2500, EventId = 52, Name = "Park Ticket" },
                new TicketCategory { Id = 111, Price = 35, MaxAmount = 2500, EventId = 53, Name = "Park Ticket" },
                new TicketCategory { Id = 112, Price = 35, MaxAmount = 2500, EventId = 54, Name = "Park Ticket" },
                new TicketCategory { Id = 113, Price = 35, MaxAmount = 2500, EventId = 55, Name = "Park Ticket" },
                new TicketCategory { Id = 114, Price = 35, MaxAmount = 2500, EventId = 56, Name = "Park Ticket" },
                //lotto arena
                new TicketCategory { Id = 115, Price = 20, MaxAmount = 2400, EventId = 57, Name = "staanplaats" },
                new TicketCategory { Id = 116, Price = 25, MaxAmount = 2400, EventId = 57, Name = "zitplaats" },
                new TicketCategory { Id = 117, Price = 35, MaxAmount = 400, EventId = 57, Name = "premium zitplaats" },
                new TicketCategory { Id = 118, Price = 25, MaxAmount = 18, EventId = 57, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 119, Price = 39, MaxAmount = 2400, EventId = 58, Name = "staanplaats" },
                new TicketCategory { Id = 120, Price = 50, MaxAmount = 2400, EventId = 58, Name = "zitplaats" },
                new TicketCategory { Id = 121, Price = 73, MaxAmount = 400, EventId = 58, Name = "premium zitplaats" },
                new TicketCategory { Id = 122, Price = 50, MaxAmount = 18, EventId = 58, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 123, Price = 32, MaxAmount = 2400, EventId = 59, Name = "staanplaats" },
                new TicketCategory { Id = 124, Price = 42, MaxAmount = 2400, EventId = 59, Name = "zitplaats" },
                new TicketCategory { Id = 125, Price = 59, MaxAmount = 400, EventId = 59, Name = "premium zitplaats" },
                new TicketCategory { Id = 126, Price = 52, MaxAmount = 18, EventId = 59, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 127, Price = 28.5, MaxAmount = 2400, EventId = 60, Name = "staanplaats" },
                new TicketCategory { Id = 128, Price = 39.7, MaxAmount = 2400, EventId = 60, Name = "zitplaats" },
                new TicketCategory { Id = 129, Price = 49.78, MaxAmount = 400, EventId = 60, Name = "premium zitplaats" },
                new TicketCategory { Id = 130, Price = 30, MaxAmount = 18, EventId = 60, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 131, Price = 35, MaxAmount = 2400, EventId = 61, Name = "staanplaats" },
                new TicketCategory { Id = 132, Price = 41.49, MaxAmount = 2400, EventId = 61, Name = "zitplaats" },
                new TicketCategory { Id = 133, Price = 45, MaxAmount = 400, EventId = 61, Name = "premium zitplaats" },
                new TicketCategory { Id = 134, Price = 38, MaxAmount = 18, EventId = 61, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 135, Price = 39, MaxAmount = 2400, EventId = 62, Name = "staanplaats" },
                new TicketCategory { Id = 136, Price = 45, MaxAmount = 2400, EventId = 62, Name = "zitplaats" },
                new TicketCategory { Id = 137, Price = 56, MaxAmount = 400, EventId = 62, Name = "premium zitplaats" },
                new TicketCategory { Id = 138, Price = 45, MaxAmount = 18, EventId = 62, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 139, Price = 39, MaxAmount = 2400, EventId = 63, Name = "staanplaats" },
                new TicketCategory { Id = 140, Price = 45, MaxAmount = 2400, EventId = 63, Name = "zitplaats" },
                new TicketCategory { Id = 141, Price = 56, MaxAmount = 400, EventId = 63, Name = "premium zitplaats" },
                new TicketCategory { Id = 142, Price = 45, MaxAmount = 18, EventId = 63, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 143, Price = 39, MaxAmount = 2400, EventId = 64, Name = "staanplaats" },
                new TicketCategory { Id = 144, Price = 45, MaxAmount = 2400, EventId = 64, Name = "zitplaats" },
                new TicketCategory { Id = 145, Price = 56, MaxAmount = 400, EventId = 64, Name = "premium zitplaats" },
                new TicketCategory { Id = 146, Price = 45, MaxAmount = 18, EventId = 64, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 147, Price = 32.99, MaxAmount = 2400, EventId = 65, Name = "staanplaats" },
                new TicketCategory { Id = 148, Price = 35, MaxAmount = 2400, EventId = 65, Name = "zitplaats" },
                new TicketCategory { Id = 149, Price = 40, MaxAmount = 400, EventId = 65, Name = "premium zitplaats" },
                new TicketCategory { Id = 150, Price = 35, MaxAmount = 18, EventId = 65, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 151, Price = 38.59, MaxAmount = 2400, EventId = 66, Name = "staanplaats" },
                new TicketCategory { Id = 152, Price = 40.5, MaxAmount = 2400, EventId = 66, Name = "zitplaats" },
                new TicketCategory { Id = 153, Price = 50, MaxAmount = 400, EventId = 66, Name = "premium zitplaats" },
                new TicketCategory { Id = 154, Price = 40, MaxAmount = 18, EventId = 66, Name = "rolstoelgebruiker" },
                new TicketCategory { Id = 155, Price = 38.59, MaxAmount = 2400, EventId = 67, Name = "staanplaats" },
                new TicketCategory { Id = 156, Price = 40.5, MaxAmount = 2400, EventId = 67, Name = "zitplaats" },
                new TicketCategory { Id = 157, Price = 50, MaxAmount = 400, EventId = 67, Name = "premium zitplaats" },
                new TicketCategory { Id = 158, Price = 40, MaxAmount = 18, EventId = 67, Name = "rolstoelgebruiker" },
                //stadsschouwburg antwerpen
                new TicketCategory { Id = 159, Price = 35, MaxAmount = 1200, EventId = 68, Name = "regular" },
                new TicketCategory { Id = 160, Price = 45, MaxAmount = 600, EventId = 68, Name = "better seat" },
                new TicketCategory { Id = 161, Price = 65, MaxAmount = 200, EventId = 68, Name = "hot seat" },
                new TicketCategory { Id = 162, Price = 40, MaxAmount = 1200, EventId = 69, Name = "regular" },
                new TicketCategory { Id = 163, Price = 45, MaxAmount = 600, EventId = 69, Name = "better seat" },
                new TicketCategory { Id = 164, Price = 55, MaxAmount = 200, EventId = 69, Name = "hot seat" },
                new TicketCategory { Id = 165, Price = 40, MaxAmount = 1200, EventId = 70, Name = "regular" },
                new TicketCategory { Id = 166, Price = 45, MaxAmount = 600, EventId = 70, Name = "better seat" },
                new TicketCategory { Id = 167, Price = 55, MaxAmount = 200, EventId = 70, Name = "hot seat" },
                new TicketCategory { Id = 168, Price = 38, MaxAmount = 1200, EventId = 71, Name = "regular" },
                new TicketCategory { Id = 169, Price = 40, MaxAmount = 600, EventId = 71, Name = "better seat" },
                new TicketCategory { Id = 170, Price = 50, MaxAmount = 200, EventId = 71, Name = "hot seat" },
                //chez nique
                new TicketCategory { Id = 171, Price = 1, MaxAmount = 25, EventId = 76, Name = "bbq tuin" }

                );
            });
        }

        private static void SeedTicketProviders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketProvider>(x =>
            {
                using var hmac = new HMACSHA512();
                x.HasData(
                new TicketProvider { Id = 1, NameProvider = "Vooruit", PhoneNumber = "09 267 28 20", Email = "info@vooruit.be", BankAccount = "BE78 3590 0754 7674", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 2, NameProvider = "WAREONE.world bvba", PhoneNumber = "09 147 27 78", Email = "info@tomorrowland.be", BankAccount = "BE78 7854 3585 7820", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 3, NameProvider = "Live Nation Festivals NV", PhoneNumber = "09 754 87 78", Email = "info@rockwerchter.be", BankAccount = "BE78 7768 3578 1220", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 4, NameProvider = "Couleur Cafe", PhoneNumber = "09 785 24 86", Email = "info@couleurcafe.be", BankAccount = "BE76 5455 8725 7824", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 5, NameProvider = "Chokri Mahassine", PhoneNumber = "09 765 78 86", Email = "info@pukkelpop.be", BankAccount = "BE34 8792 4687 2565", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 6, NameProvider = "Extrema", PhoneNumber = "09 485 35 41", Email = "info@extremaoutdoor.be", BankAccount = "BE55 7865 7874 1237", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 7, NameProvider = "Sportpaleis Group NV", PhoneNumber = "09 879 87 74", Email = "info@sportpaleisgroup.be", BankAccount = "BE78 6872 3968 7821", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 8, NameProvider = "eLiXir", PhoneNumber = "09 782 71 42", Email = "info@elixir.be", BankAccount = "BE55 7865 7874 1237", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 9, NameProvider = "Team Trix", PhoneNumber = "09 456 79 17", Email = "info@trix.be", BankAccount = "BE55 4752 7836 4878", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider },
                new TicketProvider { Id = 10, NameProvider = "Chez Nique vzw", PhoneNumber = "09 022 44 57", Email = "info@cheznique.be", BankAccount = "BE57 7862 1427 3457", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketProvider }
                );
            });
        }

        private static void SeedTicketCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketCustomer>(x =>
            {
                using var hmac = new HMACSHA512();
                x.HasData(
                new TicketCustomer { Id = 1, FirstName = "Kobe", LastName = "Delobelle", PhoneNumber = "0473 288 888", Email = "kobe@mail.com", BankAccount = "BE68 5390 0754 7034", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 2, FirstName = "Ward", LastName = "Impe", PhoneNumber = "0473 422 458", Email = "ward@mail.com", BankAccount = "BE68 6990 5800 7574", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 3, FirstName = "Pieter", LastName = "Corp",PhoneNumber = "0453 288 888", Email = "Pieter@mail.com", BankAccount = "BE60 5590 0994 7021", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 4, FirstName = "Seba", LastName = "Stiaan", PhoneNumber = "0485 345 349", Email = "Seba@mail.com", BankAccount = "BE70 5560 1278 7078", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 5, FirstName = "Nick", LastName = "Angularlover", PhoneNumber = "0478 365 852", Email = "Nick@mail.com", BankAccount = "BE77 7893 0824 7304", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 6, FirstName = "Dries", LastName = "Maes", PhoneNumber = "0432 457 896", Email = "Dries@mail.com", BankAccount = "BE41 7563 7835 0157", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 7, FirstName = "Olivia", LastName = "Goossens", PhoneNumber = "0478 687 138", Email = "Olivia@mail.com", BankAccount = "BE96 4278 6420 5496", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 8, FirstName = "Mila", LastName = "Vandevoorde", PhoneNumber = "0485 377 352", Email = "Mila@mail.com", BankAccount = "BE77 1046 8642 5676", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 9, FirstName = "Alice", LastName = "Mcgregor", PhoneNumber = "0478 785 125", Email = "Alice@mail.com", BankAccount = "BE86 7831 5701 5684", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 10, FirstName = "Louise", LastName = "Degroote", PhoneNumber = "0477 765 782", Email = "Louise@mail.com", BankAccount = "BE68 4578 3025 7304", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 11, FirstName = "Mohamed", LastName = "Yilmaz", PhoneNumber = "0472 752 785", Email = "Mohamed@mail.com", BankAccount = "BE89 4785 2015 3065", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 12, FirstName = "Emir", LastName = "Öztürk", PhoneNumber = "0473 478 795", Email = "Emir@mail.com", BankAccount = "BE58 7520 4778 8214", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 13, FirstName = "Kurt", LastName = "Debolle", PhoneNumber = "0478 140 349", Email = "Kurt@mail.com", BankAccount = "BE72 0145 7857 6375", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 14, FirstName = "Arthur", LastName = "Vangeest", PhoneNumber = "0490 785 457", Email = "Arthur@mail.com", BankAccount = "BE86 4576 0445 4873", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 15, FirstName = "Noah", LastName = "Vanarke", PhoneNumber = "0475 850 852", Email = "Noah@mail.com", BankAccount = "BE69 2467 0468 0478", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer },
                new TicketCustomer { Id = 16, FirstName = "Victor", LastName = "De Putte", PhoneNumber = "0488 754 752", Email = "Victor@mail.com", BankAccount = "BE88 4785 9785 9620", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), Role = Roles.TicketCustomer }
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
                new Venue { Id = 10, Name = "Extrema Outdoor", Capacity = 60000 },
                new Venue { Id = 11, Name = "Lotto Arena", Capacity = 5218 },
                new Venue { Id = 12, Name = "Stadsschouwburg Antwerpen", Capacity = 2000 },
                new Venue { Id = 13, Name = "Chez Nique", Capacity = 25 }
                );
            });
        }
    }
}