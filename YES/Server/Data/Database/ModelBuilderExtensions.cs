using System;
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
                new Event { Id = 1, TicketProviderId = 1, VenueId = 1, Status = Status.Completed, EventInfoId = 1 },
                new Event { Id = 2, TicketProviderId = 1, VenueId = 1, Status = Status.Default, EventInfoId = 2 },
                new Event { Id = 3, TicketProviderId = 1, VenueId = 1, Status = Status.Default, EventInfoId = 3 },
                new Event { Id = 4, TicketProviderId = 1, VenueId = 1, Status = Status.ToBeAnnounced, EventInfoId = 4 },
                new Event { Id = 5, TicketProviderId = 7, VenueId = 2, Status = Status.Postponed, EventInfoId = 5 },
                new Event { Id = 6, TicketProviderId = 7, VenueId = 2, Status = Status.Postponed, EventInfoId = 6 },
                new Event { Id = 7, TicketProviderId = 7, VenueId = 2, Status = Status.Default, EventInfoId = 7 },
                new Event { Id = 8, TicketProviderId = 7, VenueId = 2, Status = Status.Default, EventInfoId = 8 },
                new Event { Id = 9, TicketProviderId = 7, VenueId = 2, Status = Status.Default, EventInfoId = 9 },
                new Event { Id = 10, TicketProviderId = 9, VenueId = 3, Status = Status.Default, EventInfoId = 10 },
                new Event { Id = 11, TicketProviderId = 9, VenueId = 3, Status = Status.Default, EventInfoId = 11 },
                new Event { Id = 12, TicketProviderId = 9, VenueId = 3, Status = Status.Cancelled, EventInfoId = 12 },
                new Event { Id = 13, TicketProviderId = 8, VenueId = 4, Status = Status.SoldOut, EventInfoId = 13 },
                new Event { Id = 14, TicketProviderId = 7, VenueId = 5, Status = Status.Relocated, EventInfoId = 14 },
                new Event { Id = 15, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed, EventInfoId = 15 },
                new Event { Id = 16, TicketProviderId = 7, VenueId = 5, Status = Status.Cancelled, EventInfoId = 16 },
                new Event { Id = 17, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed, EventInfoId = 17 },
                new Event { Id = 18, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed, EventInfoId = 18 },
                new Event { Id = 19, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed, EventInfoId = 19 },
                new Event { Id = 20, TicketProviderId = 7, VenueId = 5, Status = Status.Postponed, EventInfoId = 20 },
                new Event { Id = 21, TicketProviderId = 7, VenueId = 5, Status = Status.Default, EventInfoId = 21 },
                new Event { Id = 22, TicketProviderId = 7, VenueId = 5, Status = Status.Default, EventInfoId = 22 },
                new Event { Id = 23, TicketProviderId = 2, VenueId = 6, Status = Status.Default, EventInfoId = 23 },
                new Event { Id = 24, TicketProviderId = 2, VenueId = 6, Status = Status.Default, EventInfoId = 24 },
                new Event { Id = 25, TicketProviderId = 2, VenueId = 6, Status = Status.Default, EventInfoId = 25 },
                new Event { Id = 26, TicketProviderId = 2, VenueId = 6, Status = Status.Default, EventInfoId = 26 },
                new Event { Id = 27, TicketProviderId = 2, VenueId = 6, Status = Status.Default, EventInfoId = 27 },
                new Event { Id = 28, TicketProviderId = 2, VenueId = 6, Status = Status.Default, EventInfoId = 28 },
                new Event { Id = 29, TicketProviderId = 5, VenueId = 9, Status = Status.Default, EventInfoId = 29 },
                new Event { Id = 30, TicketProviderId = 5, VenueId = 9, Status = Status.Default, EventInfoId = 30 },
                new Event { Id = 31, TicketProviderId = 5, VenueId = 9, Status = Status.Default, EventInfoId = 31 },
                new Event { Id = 32, TicketProviderId = 5, VenueId = 9, Status = Status.Default, EventInfoId = 32 },
                new Event { Id = 33, TicketProviderId = 6, VenueId = 10, Status = Status.Default, EventInfoId = 33 },
                new Event { Id = 34, TicketProviderId = 6, VenueId = 10, Status = Status.Default, EventInfoId = 34 },
                new Event { Id = 35, TicketProviderId = 6, VenueId = 10, Status = Status.Default, EventInfoId = 35 },
                new Event { Id = 36, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 36 },
                new Event { Id = 37, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 37 },
                new Event { Id = 38, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 38 },
                new Event { Id = 39, TicketProviderId = 3, VenueId = 9, Status = Status.SoldOut, EventInfoId = 39 },
                new Event { Id = 40, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 40 },
                new Event { Id = 41, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 41 },
                new Event { Id = 42, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 42 },
                new Event { Id = 43, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 43 },
                new Event { Id = 44, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 44 },
                new Event { Id = 45, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 45 },
                new Event { Id = 46, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 46 },
                new Event { Id = 47, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 47 },
                new Event { Id = 48, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 48 },
                new Event { Id = 49, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 49 },
                new Event { Id = 50, TicketProviderId = 3, VenueId = 9, Status = Status.SoldOut, EventInfoId = 50 },
                new Event { Id = 51, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 51 },
                new Event { Id = 52, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 52 },
                new Event { Id = 53, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 53 },
                new Event { Id = 54, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 54 },
                new Event { Id = 55, TicketProviderId = 3, VenueId = 9, Status = Status.SoldOut, EventInfoId = 55 },
                new Event { Id = 56, TicketProviderId = 3, VenueId = 9, Status = Status.Default, EventInfoId = 56 }
                );
            });
        }

        private static void SeedEventInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventInfo>(x =>
            {
                x.HasData(
                new EventInfo { Id = 1, EventId = 1, Name = "EK België-Rusland", Description = "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg" },
                new EventInfo { Id = 2, EventId = 2, Name = "EK België-Denemarken", Description = "Uitzending EK wedstrijd tussen België en Denemarken, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("18/06/2021 18:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3839//EK_Denemarken_Belgie_op_groot_scherm_", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg" },
                new EventInfo { Id = 3, EventId = 3, Name = "EK België-Finland", Description = "Uitzending EK wedstrijd tussen België en Finland, wees er tijdig bij want door corona zijn de plaatsen beperkt", EventDate = DateTime.ParseExact("21/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), MaxAvailableTickets = 500, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3841//EK_Finland_Belgie_op_groot_scherm", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg" },
                new EventInfo { Id = 4, EventId = 4, Name = "Terras Sessie: Joni Sheila", Description = "Wees er tijdig bij want door corona zijn de plaatsen beperkt", MaxAvailableTickets = 50, WebsiteUrl = "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila", BannerImgUrl = "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg" },
                new EventInfo { Id = 5, EventId = 5, Name = "Kommil Foo", EventDate = DateTime.ParseExact("18/07/2021 19:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", MaxAvailableTickets = 1000, WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg" },
                new EventInfo { Id = 6, EventId = 6, Name = "Kommil Foo", EventDate = DateTime.ParseExact("19/07/2021 19:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", MaxAvailableTickets = 1000, WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg" },
                new EventInfo { Id = 7, EventId = 7, Name = "Daniel Sloss", EventDate = DateTime.ParseExact("03/10/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De gloednieuwe, 11e solovoorstelling van de Schotse internationale comedy superster komt, vlak na zijn baanbrekende wereldsucces ‘Daniel Sloss: X’, naar Capitole Gent en Stadsschouwburg Antwerpen.", MaxAvailableTickets = 2000, WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2021-2022/daniel-sloss", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/2946/58d62f6c31062dda0be21c3983929ea88d9fb007/billboard.jpg" },
                new EventInfo { Id = 8, EventId = 8, Name = "An Evening with Alex Agnew", EventDate = DateTime.ParseExact("15/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", MaxAvailableTickets = 1000, WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg" },
                new EventInfo { Id = 9, EventId = 9, Name = "An Evening with Alex Agnew", EventDate = DateTime.ParseExact("16/09/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", MaxAvailableTickets = 1000, WebsiteUrl = "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg" },
                new EventInfo { Id = 10, EventId = 10, Name = "Lili Grace / Rooftop Concert", EventDate = DateTime.ParseExact("24/06/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Lili Grace, dat zijn de zussen Nelle en Dienne, en zij doen ongemeen boeiende dingen met twee stemmen, cello, keyboards en electronica. Met hun dark-pop haalden ze in 2012 de finale van Humo's Rock Rally en deden ze voorprogramma's voor onder meer Trentemøller, CocoRosie en Nils Frahm.", MaxAvailableTickets = 50, WebsiteUrl = "https://www.trixonline.be/nl/programma/lili-grace/2756/", BannerImgUrl = "https://www.trixonline.be/images/events/detail/liligrace-web.png" },
                new EventInfo { Id = 11, EventId = 11, Name = "The Howl And The Hum", EventDate = DateTime.ParseExact("25/09/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Donkere, hypnotiserende pop uit de UK. Meng The Killers met U2 en je krijgt een soort beschrijving van hun sound (StuBru)", MaxAvailableTickets = 500, WebsiteUrl = "https://www.trixonline.be/nl/programma/the-howl-and-the-hum/2713/", BannerImgUrl = "https://www.trixonline.be/images/lightbox/15070028-min-scaled.jpg" },
                new EventInfo { Id = 12, EventId = 12, Name = "The Armed", EventDate = DateTime.ParseExact("18/10/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Dit concert is afgelast. Alle tickets worden automatisch terugbetaald.", MaxAvailableTickets = 500, WebsiteUrl = "https://www.trixonline.be/nl/programma/the-armed/2723/", BannerImgUrl = "https://www.trixonline.be/images/lightbox/the-armedall-eight.jpg" },
                new EventInfo { Id = 13, EventId = 13, Name = "VJ Ward", EventDate = DateTime.ParseExact("10/09/2021 01:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "VJ Ward in the Mix", MaxAvailableTickets = 100, WebsiteUrl = "https://www.facebook.com/Dj.Ward.Impe/", BannerImgUrl = "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/68947152_10156578134447644_7759879836461432832_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=IDm1dnxmhosAX-EYdU6&_nc_ht=scontent-bru2-1.xx&oh=18d225698aa70604374adbaf32077950&oe=60CA125B" },
                new EventInfo { Id = 14, EventId = 14, Name = "VJ Ward / eLiXir on Tour", EventDate = DateTime.ParseExact("10/10/2021 23:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Na lang anticiperen krijgt VJ Ward een kans zich op het grote podium te bewijzen. Dit jonge talent draait overal de pannen van het dak, mis deze kans dus niet want de plaatsen zijn beperkt.", MaxAvailableTickets = 10000, WebsiteUrl = "https://www.facebook.com/Dj.Ward.Impe/", BannerImgUrl = "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/68947152_10156578134447644_7759879836461432832_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=IDm1dnxmhosAX-EYdU6&_nc_ht=scontent-bru2-1.xx&oh=18d225698aa70604374adbaf32077950&oe=60CA125B" },
                new EventInfo { Id = 15, EventId = 15, Name = "Alicia Keys: The World Tour", EventDate = DateTime.ParseExact("15/06/2021", "dd/MM/yyyy", null), Description = "Alicia Keys is terug. En hoe! Het muziekicoon met 15 GRAMMY-prijzen op haar naam kondigt vandaag haar nieuwe album ‘ALICIA’ aan met release voorzien op 20 maart bij Sony Music, en haar langverwachte terugkeer naar de podia met haar ‘ALICIA – THE WORLD TOUR’.", MaxAvailableTickets = 10000, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/alicia-keys", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/3055/2bc5d811ace73d22a3f95f204665a66dfcbfd756/billboard.jpg" },
                new EventInfo { Id = 16, EventId = 16, Name = "Iron Maiden: Legacy Of The Beast Tour", EventDate = DateTime.ParseExact("27/06/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Als gevolg van de pandemie had Iron Maiden zijn ‘Legacy of the Beast Tour 2020’ verplaatst naar juni/juli 2021. Normaal zou de band op zondag 27 juni 2021 een headlineshow spelen in het Antwerps Sportpaleis. Helaas moet de tour weer met een jaar verschoven worden. Maar niet getreurd, de band staat in 2022 opnieuw op Graspop Metal Meeting om het beste van zichzelf te geven!", MaxAvailableTickets = 10000, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2020-2021/iron-maiden", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2813/4bd008b389321af80580493d3cb77243d46546b3/billboard.jpg" },
                new EventInfo { Id = 17, EventId = 17, Name = "The Weeknd: The After Hours Tour", EventDate = DateTime.ParseExact("28/09/2022 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", MaxAvailableTickets = 23359, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg" },
                new EventInfo { Id = 18, EventId = 18, Name = "The Weeknd: The After Hours Tour", EventDate = DateTime.ParseExact("29/09/2022 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", MaxAvailableTickets = 23359, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg" },
                new EventInfo { Id = 19, EventId = 19, Name = "Elton John: Farewell Yellow Brick Road Tour", EventDate = DateTime.ParseExact("16/10/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", MaxAvailableTickets = 10000, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg" },
                new EventInfo { Id = 20, EventId = 20, Name = "Elton John: Farewell Yellow Brick Road Tour", EventDate = DateTime.ParseExact("17/10/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", MaxAvailableTickets = 10000, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john", BannerImgUrl = "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg" },
                new EventInfo { Id = 21, EventId = 21, Name = "Tomorrowland presents: Dimitri Vegas & Like Mike Garden of Madness", EventDate = DateTime.ParseExact("17/12/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Het is nú al uitkijken naar het najaar, want Tomorrowland en Dimitri Vegas & Like Mike toveren het Antwerps Sportpaleis opnieuw om tot een magisch indoorfestival. Daarvoor halen ze alles uit de kast: het beloven (voor de achtste keer al!) twee waanzinnig spectaculaire avonden te worden met de grootste hits maar ook heel wat nieuwe muziek én een vleugje Tomorrowland magie.", MaxAvailableTickets = 23359, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/tomorrowland-presents-dimitri-vegas--like-mike", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3019/71b8033e72484c9da1555c70d71d48567f708f87/banner.jpg" },
                new EventInfo { Id = 22, EventId = 22, Name = "Tomorrowland presents: Dimitri Vegas & Like Mike Garden of Madness", EventDate = DateTime.ParseExact("18/12/2021 19:30:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Het is nú al uitkijken naar het najaar, want Tomorrowland en Dimitri Vegas & Like Mike toveren het Antwerps Sportpaleis opnieuw om tot een magisch indoorfestival. Daarvoor halen ze alles uit de kast: het beloven (voor de achtste keer al!) twee waanzinnig spectaculaire avonden te worden met de grootste hits maar ook heel wat nieuwe muziek én een vleugje Tomorrowland magie.", MaxAvailableTickets = 23359, WebsiteUrl = "https://www.sportpaleis.be/nl/kalender/2021-2022/tomorrowland-presents-dimitri-vegas--like-mike", BannerImgUrl = "http://static.sportpaleisgroep.be/sportpaleis/img/events/3019/71b8033e72484c9da1555c70d71d48567f708f87/banner.jpg" },
                new EventInfo { Id = 23, EventId = 23, Name = "Tomorrowland (Weekend 1: Day 1)", EventDate = DateTime.ParseExact("27/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", MaxAvailableTickets = 200000, WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 24, EventId = 24, Name = "Tomorrowland (Weekend 1: Day 2)", EventDate = DateTime.ParseExact("28/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", MaxAvailableTickets = 200000, WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 25, EventId = 25, Name = "Tomorrowland (Weekend 1: Day 3)", EventDate = DateTime.ParseExact("29/08/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", MaxAvailableTickets = 200000, WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 26, EventId = 26, Name = "Tomorrowland (Weekend 2: Day 1)", EventDate = DateTime.ParseExact("03/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", MaxAvailableTickets = 200000, WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 27, EventId = 27, Name = "Tomorrowland (Weekend 2: Day 2)", EventDate = DateTime.ParseExact("04/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", MaxAvailableTickets = 200000, WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 28, EventId = 28, Name = "Tomorrowland (Weekend 2: Day 3)", EventDate = DateTime.ParseExact("05/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", MaxAvailableTickets = 200000, WebsiteUrl = "https://www.tomorrowland.com/en/festival/welcome", BannerImgUrl = "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg" },
                new EventInfo { Id = 29, EventId = 29, Name = "Pukkelpop (Day 1)", EventDate = DateTime.ParseExact("19/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", MaxAvailableTickets = 75000, WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg" },
                new EventInfo { Id = 30, EventId = 30, Name = "Pukkelpop (Day 2)", EventDate = DateTime.ParseExact("20/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", MaxAvailableTickets = 75000, WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg" },
                new EventInfo { Id = 31, EventId = 31, Name = "Pukkelpop (Day 3)", EventDate = DateTime.ParseExact("21/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", MaxAvailableTickets = 75000, WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg" },
                new EventInfo { Id = 32, EventId = 32, Name = "Pukkelpop (Day 4)", EventDate = DateTime.ParseExact("22/09/2021 11:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", MaxAvailableTickets = 75000, WebsiteUrl = "https://www.pukkelpop.be/en/", BannerImgUrl = "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg" },
                new EventInfo { Id = 33, EventId = 33, Name = "Extrema Outdoor Extra: September edition (Day 1)", EventDate = DateTime.ParseExact("17/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", MaxAvailableTickets = 60000, WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/162265388_3896238790437215_4033182633678490037_n.jpg?_nc_cat=102&ccb=1-3&_nc_sid=340051&_nc_ohc=NJa6V9eplsUAX9HsJnM&_nc_ht=scontent-bru2-1.xx&oh=3194a5fb0274bb9d1bfd2979a66d43c5&oe=60C9D8E1" },
                new EventInfo { Id = 34, EventId = 34, Name = "Extrema Outdoor Extra: September edition (Day 2)", EventDate = DateTime.ParseExact("18/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", MaxAvailableTickets = 60000, WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/162265388_3896238790437215_4033182633678490037_n.jpg?_nc_cat=102&ccb=1-3&_nc_sid=340051&_nc_ohc=NJa6V9eplsUAX9HsJnM&_nc_ht=scontent-bru2-1.xx&oh=3194a5fb0274bb9d1bfd2979a66d43c5&oe=60C9D8E1" },
                new EventInfo { Id = 35, EventId = 35, Name = "Extrema Outdoor Extra: September edition (Day 3)", EventDate = DateTime.ParseExact("19/09/2021 12:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", MaxAvailableTickets = 60000, WebsiteUrl = "https://extrema.be", BannerImgUrl = "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/162265388_3896238790437215_4033182633678490037_n.jpg?_nc_cat=102&ccb=1-3&_nc_sid=340051&_nc_ohc=NJa6V9eplsUAX9HsJnM&_nc_ht=scontent-bru2-1.xx&oh=3194a5fb0274bb9d1bfd2979a66d43c5&oe=60C9D8E1" },
                new EventInfo { Id = 36, EventId = 36, Name = "Balthazar + Sohnarr | Werchter Parklife", EventDate = DateTime.ParseExact("01/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 37, EventId = 37, Name = "Goose | Werchter Parklife", EventDate = DateTime.ParseExact("02/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 38, EventId = 38, Name = "Arsenal + Tin Fingers | Werchter Parklife", EventDate = DateTime.ParseExact("03/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 39, EventId = 39, Name = "Lil Kleine + Ronnie Flex & The Fam | Werchter Parklife", EventDate = DateTime.ParseExact("04/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 40, EventId = 40, Name = "Bazart + Yong Yello | Werchter Parklife", EventDate = DateTime.ParseExact("08/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 41, EventId = 41, Name = "Gabriel Rios + Eefje De Visser + Emmy D'Arc | Werchter Parklife", EventDate = DateTime.ParseExact("09/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 42, EventId = 42, Name = "Bart Peeters & De Ideale Mannen | Werchter Parklife", EventDate = DateTime.ParseExact("10/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 43, EventId = 43, Name = "Tourist LeMC | Werchter Parklife", EventDate = DateTime.ParseExact("11/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 44, EventId = 44, Name = "Goose + Glints | Werchter Parklife", EventDate = DateTime.ParseExact("15/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 45, EventId = 45, Name = "Blackwave. + Charles + Emma Bale ", EventDate = DateTime.ParseExact("16/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 46, EventId = 46, Name = "De Mens + Ruben Block | Werchter Parklife", EventDate = DateTime.ParseExact("17/08/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 47, EventId = 47, Name = "Regi Live + Cleymans & Van Geel | Werchter Parklife", EventDate = DateTime.ParseExact("18/08/2021 15:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 48, EventId = 48, Name = "Jasper Steverlinck + Portland | Werchter Parklife", EventDate = DateTime.ParseExact("18/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 49, EventId = 49, Name = "Alex Agnew | Werchter Parklife", EventDate = DateTime.ParseExact("22/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 50, EventId = 50, Name = "Zwangere Guy + Miss Angel + Chibi Ichigo | Werchter Parklife", EventDate = DateTime.ParseExact("23/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 51, EventId = 51, Name = "Whispering Sons + Millionaire | Werchter Parklife", EventDate = DateTime.ParseExact("24/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 52, EventId = 52, Name = "Snelle & De Lieve Jongens Band | Werchter Parklife", EventDate = DateTime.ParseExact("25/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 53, EventId = 53, Name = "Bart Peters & De Ideale Mannen | Werchter Parklife", EventDate = DateTime.ParseExact("29/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 54, EventId = 54, Name = "Selah Sue + Meskerem Mees + TheColorGrey + Sam De Neef | Werchter Parklife", EventDate = DateTime.ParseExact("30/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 55, EventId = 55, Name = "Niels Destadsbader | Werchter Parklife", EventDate = DateTime.ParseExact("31/08/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" },
                new EventInfo { Id = 56, EventId = 56, Name = "Black Box Revelation + Brutus + Equal Idiots + Stake + KillTheLogo | Werchter Parklife", EventDate = DateTime.ParseExact("01/09/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null), Description = "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", MaxAvailableTickets = 2500, WebsiteUrl = "https://www.rockwerchter.be/nl/", BannerImgUrl = "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg" }

                );
            });
        }

        private static void SeedTickets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(x =>
            {
                x.HasData(
                new Ticket { Id = 1, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 2, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 3, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 4, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 5, EventId = 1, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 6, EventId = 1, TicketCustomerId = 2, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 7, EventId = 1, TicketCustomerId = 2, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 8, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 9, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 10, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 11, EventId = 1, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 12, EventId = 1, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 13, EventId = 1, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 14, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 15, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 16, EventId = 1, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("12/06/2021 21:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 17, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 18, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 19, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 20, EventId = 13, TicketCustomerId = 1, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 21, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 22, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 23, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 24, EventId = 13, TicketCustomerId = 3, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 25, EventId = 13, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 26, EventId = 13, TicketCustomerId = 4, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 27, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 28, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 29, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 30, EventId = 13, TicketCustomerId = 5, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 31, EventId = 13, TicketCustomerId = 6, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 32, EventId = 13, TicketCustomerId = 7, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 33, EventId = 13, TicketCustomerId = 8, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 34, EventId = 13, TicketCustomerId = 8, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 35, EventId = 13, TicketCustomerId = 9, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 36, EventId = 13, TicketCustomerId = 9, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 37, EventId = 13, TicketCustomerId = 10, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 38, EventId = 13, TicketCustomerId = 11, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 39, EventId = 13, TicketCustomerId = 12, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 40, EventId = 13, TicketCustomerId = 12, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 41, EventId = 13, TicketCustomerId = 13, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 42, EventId = 13, TicketCustomerId = 13, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 43, EventId = 13, TicketCustomerId = 13, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 44, EventId = 13, TicketCustomerId = 14, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 45, EventId = 13, TicketCustomerId = 15, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 46, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 47, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 48, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 49, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) },
                new Ticket { Id = 50, EventId = 13, TicketCustomerId = 16, DateOfPurchase = DateTime.ParseExact("14/06/2021 20:00:00", "dd/MM/yyyy HH:mm:ss", null) }
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
                new TicketPrice { Id = 16, Category = "zitplaats", Price = 1, TicketId = 16 },
                new TicketPrice { Id = 17, Category = "VIP", Price = 10, TicketId = 17 },
                new TicketPrice { Id = 18, Category = "VIP", Price = 10, TicketId = 18 },
                new TicketPrice { Id = 19, Category = "VIP", Price = 10, TicketId = 19 },
                new TicketPrice { Id = 20, Category = "VIP", Price = 10, TicketId = 20 },
                new TicketPrice { Id = 21, Category = "VIP", Price = 10, TicketId = 21 },
                new TicketPrice { Id = 22, Category = "VIP", Price = 10, TicketId = 22 },
                new TicketPrice { Id = 23, Category = "VIP", Price = 10, TicketId = 23 },
                new TicketPrice { Id = 24, Category = "VIP", Price = 10, TicketId = 24 },
                new TicketPrice { Id = 25, Category = "VIP", Price = 10, TicketId = 25 },
                new TicketPrice { Id = 26, Category = "VIP", Price = 10, TicketId = 26 },
                new TicketPrice { Id = 27, Category = "VIP", Price = 10, TicketId = 27 },
                new TicketPrice { Id = 28, Category = "VIP", Price = 10, TicketId = 28 },
                new TicketPrice { Id = 29, Category = "VIP", Price = 10, TicketId = 29 },
                new TicketPrice { Id = 30, Category = "VIP", Price = 10, TicketId = 30 },
                new TicketPrice { Id = 31, Category = "regular", Price = 5, TicketId = 31 },
                new TicketPrice { Id = 32, Category = "regular", Price = 5, TicketId = 32 },
                new TicketPrice { Id = 33, Category = "regular", Price = 5, TicketId = 33 },
                new TicketPrice { Id = 34, Category = "regular", Price = 5, TicketId = 34 },
                new TicketPrice { Id = 35, Category = "regular", Price = 5, TicketId = 35 },
                new TicketPrice { Id = 36, Category = "regular", Price = 5, TicketId = 36 },
                new TicketPrice { Id = 37, Category = "regular", Price = 5, TicketId = 37 },
                new TicketPrice { Id = 38, Category = "regular", Price = 5, TicketId = 38 },
                new TicketPrice { Id = 39, Category = "regular", Price = 5, TicketId = 39 },
                new TicketPrice { Id = 40, Category = "regular", Price = 5, TicketId = 40 },
                new TicketPrice { Id = 41, Category = "regular", Price = 5, TicketId = 41 },
                new TicketPrice { Id = 42, Category = "regular", Price = 5, TicketId = 42 },
                new TicketPrice { Id = 43, Category = "regular", Price = 5, TicketId = 43 },
                new TicketPrice { Id = 44, Category = "regular", Price = 5, TicketId = 44 },
                new TicketPrice { Id = 45, Category = "regular", Price = 5, TicketId = 45 },
                new TicketPrice { Id = 46, Category = "regular", Price = 5, TicketId = 46 },
                new TicketPrice { Id = 47, Category = "regular", Price = 5, TicketId = 47 },
                new TicketPrice { Id = 48, Category = "regular", Price = 5, TicketId = 48 },
                new TicketPrice { Id = 49, Category = "regular", Price = 5, TicketId = 49 },
                new TicketPrice { Id = 50, Category = "regular", Price = 5, TicketId = 50 }
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