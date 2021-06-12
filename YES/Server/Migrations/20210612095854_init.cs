using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YES.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxAvailableTickets = table.Column<int>(type: "int", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: true),
                    TicketProviderId = table.Column<int>(type: "int", nullable: true),
                    TicketCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_TicketCustomers_TicketCustomerId",
                        column: x => x.TicketCustomerId,
                        principalTable: "TicketCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_TicketProviders_TicketProviderId",
                        column: x => x.TicketProviderId,
                        principalTable: "TicketProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    TicketProviderId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EventInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventInfo_EventInfoId",
                        column: x => x.EventInfoId,
                        principalTable: "EventInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_TicketProviders_TicketProviderId",
                        column: x => x.TicketProviderId,
                        principalTable: "TicketProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketCustomerId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketCustomers_TicketCustomerId",
                        column: x => x.TicketCustomerId,
                        principalTable: "TicketCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPrices_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventInfo",
                columns: new[] { "Id", "BannerImgUrl", "Description", "EventDate", "EventId", "MaxAvailableTickets", "Name", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg", "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 500, "EK België-Rusland", "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm" },
                    { 20, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg", "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", new DateTime(2021, 10, 17, 19, 30, 0, 0, DateTimeKind.Unspecified), 20, 10000, "Elton John: Farewell Yellow Brick Road Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john" },
                    { 19, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg", "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", new DateTime(2021, 10, 16, 19, 30, 0, 0, DateTimeKind.Unspecified), 19, 10000, "Elton John: Farewell Yellow Brick Road Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john" },
                    { 18, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg", "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", new DateTime(2022, 9, 29, 19, 30, 0, 0, DateTimeKind.Unspecified), 18, 23359, "The Weeknd: The After Hours Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd" },
                    { 17, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg", "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", new DateTime(2022, 9, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), 17, 23359, "The Weeknd: The After Hours Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd" },
                    { 16, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2813/4bd008b389321af80580493d3cb77243d46546b3/billboard.jpg", "Als gevolg van de pandemie had Iron Maiden zijn ‘Legacy of the Beast Tour 2020’ verplaatst naar juni/juli 2021. Normaal zou de band op zondag 27 juni 2021 een headlineshow spelen in het Antwerps Sportpaleis. Helaas moet de tour weer met een jaar verschoven worden. Maar niet getreurd, de band staat in 2022 opnieuw op Graspop Metal Meeting om het beste van zichzelf te geven!", new DateTime(2021, 6, 27, 19, 30, 0, 0, DateTimeKind.Unspecified), 16, 10000, "Iron Maiden: Legacy Of The Beast Tour", "https://www.sportpaleis.be/nl/kalender/2020-2021/iron-maiden" },
                    { 15, "https://static.sportpaleisgroep.be/sportpaleis/img/events/3055/2bc5d811ace73d22a3f95f204665a66dfcbfd756/billboard.jpg", "Alicia Keys is terug. En hoe! Het muziekicoon met 15 GRAMMY-prijzen op haar naam kondigt vandaag haar nieuwe album ‘ALICIA’ aan met release voorzien op 20 maart bij Sony Music, en haar langverwachte terugkeer naar de podia met haar ‘ALICIA – THE WORLD TOUR’.", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 10000, "Alicia Keys: The World Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/alicia-keys" },
                    { 13, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/68947152_10156578134447644_7759879836461432832_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=IDm1dnxmhosAX-EYdU6&_nc_ht=scontent-bru2-1.xx&oh=18d225698aa70604374adbaf32077950&oe=60CA125B", "VJ Ward in the Mix", new DateTime(2021, 9, 10, 1, 0, 0, 0, DateTimeKind.Unspecified), 13, 100, "VJ Ward", "https://www.facebook.com/Dj.Ward.Impe/" },
                    { 12, "https://www.trixonline.be/images/lightbox/the-armedall-eight.jpg", "Dit concert is afgelast. Alle tickets worden automatisch terugbetaald.", new DateTime(2021, 10, 18, 19, 30, 0, 0, DateTimeKind.Unspecified), 12, 500, "CANCELLED: The Armed", "https://www.trixonline.be/nl/programma/the-armed/2723/" },
                    { 11, "https://www.trixonline.be/images/lightbox/15070028-min-scaled.jpg", "Donkere, hypnotiserende pop uit de UK. Meng The Killers met U2 en je krijgt een soort beschrijving van hun sound (StuBru)", new DateTime(2021, 9, 25, 19, 30, 0, 0, DateTimeKind.Unspecified), 11, 500, "The Howl And The Hum", "https://www.trixonline.be/nl/programma/the-howl-and-the-hum/2713/" },
                    { 14, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/68947152_10156578134447644_7759879836461432832_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=IDm1dnxmhosAX-EYdU6&_nc_ht=scontent-bru2-1.xx&oh=18d225698aa70604374adbaf32077950&oe=60CA125B", "Na lang anticiperen krijgt VJ Ward een kans zich op het grote podium te bewijzen. Dit jonge talent draait overal de pannen van het dak, mis deze kans dus niet want de plaatsen zijn beperkt.", new DateTime(2021, 10, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), 14, 10000, "VJ Ward / eLiXir on Tour", "https://www.facebook.com/Dj.Ward.Impe/" },
                    { 9, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg", "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", new DateTime(2021, 9, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, 1000, "An Evening with Alex Agnew", "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew" },
                    { 10, "https://www.trixonline.be/images/events/detail/liligrace-web.png", "Lili Grace, dat zijn de zussen Nelle en Dienne, en zij doen ongemeen boeiende dingen met twee stemmen, cello, keyboards en electronica. Met hun dark-pop haalden ze in 2012 de finale van Humo's Rock Rally en deden ze voorprogramma's voor onder meer Trentemøller, CocoRosie en Nils Frahm.", new DateTime(2021, 6, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), 10, 50, "Lili Grace / Rooftop Concert", "https://www.trixonline.be/nl/programma/lili-grace/2756/" },
                    { 3, "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg", "Uitzending EK wedstrijd tussen België en Finland, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, 500, "EK België-Finland", "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila" },
                    { 4, "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg", "Wees er tijdig bij want door corona zijn de plaatsen beperkt", null, 4, 50, "POSTPONED: Terras Sessie: Joni Sheila", "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila" },
                    { 5, "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg", "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", new DateTime(2021, 7, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 5, 1000, "Kommil Foo", "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo" },
                    { 2, "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg", "Uitzending EK wedstrijd tussen België en Denemarken, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 500, "EK België-Denemarken", "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila" },
                    { 7, "http://static.sportpaleisgroep.be/sportpaleis/img/events/2946/58d62f6c31062dda0be21c3983929ea88d9fb007/billboard.jpg", "De gloednieuwe, 11e solovoorstelling van de Schotse internationale comedy superster komt, vlak na zijn baanbrekende wereldsucces ‘Daniel Sloss: X’, naar Capitole Gent en Stadsschouwburg Antwerpen.", new DateTime(2021, 10, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 7, 2000, "Daniel Sloss", "http://www.capitole-gent.be/nl/kalender/2021-2022/daniel-sloss" },
                    { 8, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg", "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", new DateTime(2021, 9, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, 1000, "An Evening with Alex Agnew", "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew" },
                    { 6, "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg", "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", new DateTime(2021, 7, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, 1000, "Kommil Foo", "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo" }
                });

            migrationBuilder.InsertData(
                table: "TicketCustomers",
                columns: new[] { "Id", "AddressId", "BankAccount", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 10, 0, "BE68 4578 3025 7304", "Louise@mail.com", "Louise", "Degroote", "0477 765 782" },
                    { 16, 0, "BE88 4785 9785 9620", "Victor@mail.com", "Victor", "De Putte", "0488 754 752" },
                    { 15, 0, "BE69 2467 0468 0478", "Noah@mail.com", "Noah", "Vanarke", "0475 850 852" },
                    { 14, 0, "BE86 4576 0445 4873", "Arthur@mail.com", "Arthur", "Vangeest", "0490 785 457" },
                    { 13, 0, "BE72 0145 7857 6375", "Kurt@mail.com", "Kurt", "Debolle", "0478 140 349" },
                    { 12, 0, "BE58 7520 4778 8214", "Emir@mail.com", "Emir", "Öztürk", "0473 478 795" },
                    { 11, 0, "BE89 4785 2015 3065", "Mohamed@mail.com", "Mohamed", "Yilmaz", "0472 752 785" },
                    { 9, 0, "BE86 7831 5701 5684", "Alice@mail.com", "Alice", "Mcgregor", "0478 785 125" },
                    { 8, 0, "BE77 1046 8642 5676", "Mila@mail.com", "Mila", "Vandevoorde", "0485 377 352" },
                    { 7, 0, "BE96 4278 6420 5496", "Olivia@mail.com", "Olivia", "Goossens", "0478 687 138" },
                    { 6, 0, "BE41 7563 7835 0157", "Dries@mail.com", "Dries", "Maes", "0432 457 896" },
                    { 5, 0, "BE77 7893 0824 7304", "Nick@mail.com", "Nick", "Angularlover", "0478 365 852" },
                    { 4, 0, "BE70 5560 1278 7078", "Seba@mail.com", "Seba", "Stiaan", "0485 345 349" },
                    { 3, 0, "BE60 5590 0994 7021", "Pieter@mail.com", "Pieter", "Corp", "0453 288 888" },
                    { 2, 0, "BE68 6990 5800 7574", "ward@mail.com", "Ward", "Impe", "0473 422 458" },
                    { 1, 0, "BE68 5390 0754 7034", "kobe@mail.com", "Kobe", "Delobelle", "0473 288 888" }
                });

            migrationBuilder.InsertData(
                table: "TicketProviders",
                columns: new[] { "Id", "AddressId", "BankAccount", "Email", "NameProvider", "PhoneNumber" },
                values: new object[,]
                {
                    { 9, 0, "BE55 4752 7836 4878", "info@trix.be", "Team Trix", "09 456 79 17" },
                    { 8, 0, "BE55 7865 7874 1237", "info@elixir.be", "eLiXir", "09 782 71 42" },
                    { 7, 0, "BE78 6872 3968 7821", "info@sportpaleisgroup.be", "Sportpaleis Group NV", "09 879 87 74" },
                    { 5, 0, "BE34 8792 4687 2565", "info@pukkelpop.be", "Chokri Mahassine", "09 765 78 86" },
                    { 6, 0, "BE55 7865 7874 1237", "info@extremaoutdoor.be", "Extrema", "09 485 35 41" },
                    { 3, 0, "BE78 7768 3578 1220", "info@rockwerchter.be", "Live Nation Festivals NV", "09 754 87 78" }
                });

            migrationBuilder.InsertData(
                table: "TicketProviders",
                columns: new[] { "Id", "AddressId", "BankAccount", "Email", "NameProvider", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, 0, "BE78 7854 3585 7820", "info@tomorrowland.be", "WAREONE.world bvba", "09 147 27 78" },
                    { 1, 0, "BE78 3590 0754 7674", "info@vooruit.be", "Vooruit", "09 267 28 20" },
                    { 4, 0, "BE76 5455 8725 7824", "info@couleurcafe.be", "Couleur Cafe", "09 785 24 86" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "AddressId", "Capacity", "Name" },
                values: new object[,]
                {
                    { 9, 0, 100000, "Pukkelpop" },
                    { 1, 0, 1110, "Kunstencentrum Vooruit" },
                    { 2, 0, 2000, "Capitole Gent" },
                    { 3, 0, 1500, "Trix" },
                    { 4, 0, 200, "eLiXir Dance & Night Club" },
                    { 5, 0, 23359, "Sportpaleis" },
                    { 6, 0, 200000, "Tomorrowland" },
                    { 7, 0, 100000, "Rock Werchter" },
                    { 8, 0, 60000, "Couleur Café" },
                    { 10, 0, 60000, "Extrema Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber", "TicketCustomerId", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 2, "Gent", "België", "9000", "Tentoonstellingslaan", 1, 1, null, null },
                    { 25, "Brussel", "België", "1020", "Eeuwfeestlaan", 617, null, 4, 8 },
                    { 24, "Werchter", "België", "3118", "Festivalpark", null, null, null, 7 },
                    { 23, "Boom", "België", "2850", "Schommelei", 1, null, null, 6 },
                    { 22, "Antwerpen", "België", "2170", "Schijnpoortweg", 119, null, 7, 5 },
                    { 21, "Gent", "België", "9000", "Overpoortstraat", 60, null, 8, 4 },
                    { 20, "Antwerpen", "België", "2140", "Noordersingel", 28, null, 9, 3 },
                    { 19, "Gent", "België", "9000", "Graaf Van Vlaanderenplein", 5, null, null, 2 },
                    { 26, "Hasselt", "België", "3500", "Kempische Steenweg", null, null, null, 9 },
                    { 1, "Gent", "België", "9000", "Sint-Pietersnieuwstraat", 23, null, 1, 1 },
                    { 31, "Antwerpen", "België", "2000", "Braziliestraat", 26, null, 6, null },
                    { 30, "Hasselt", "België", "3510", "Koorstraat", 17, null, 5, null },
                    { 29, "Mechelen", "België", "2800", "Blarenberglaan", 3, null, 3, null },
                    { 28, "Antwerpen", "België", "6200", "Korte Vlierstraat", 6, null, 2, null },
                    { 18, "Oostende", "België", "8400", "Stapelhuisstraat", 17, 16, null, null },
                    { 27, "Houthalen-Helchteren", "België", "3530", "Binnenvaartstraat", null, null, null, 10 },
                    { 16, "Wevelgem", "België", "8560", "Hondsschotestraat", 83, 14, null, null },
                    { 17, "Ieper", "België", "8900", "Tybaertstraat", 27, 15, null, null },
                    { 8, "Gent", "België", "9000", "Olifantstraat", 2, 7, null, null },
                    { 7, "Gent", "België", "9000", "Olifantstraat", 26, 6, null, null },
                    { 9, "Sint-Joost-ten-Node", "België", "1210", "Kleine Dalstraat", 1, 8, null, null },
                    { 11, "Etterbeek", "België", "1040", "Waversesteenweg", 100, 9, null, null },
                    { 5, "Gent", "België", "9000", "Tijgerstraat", 24, 4, null, null },
                    { 6, "Sint-Niklaas", "België", "9100", "Apostelstraat", 79, 5, null, null },
                    { 3, "Gent", "België", "9000", "Leeuwstraat", 7, 2, null, null },
                    { 12, "Waver", "België", "1300", "Rue de la Cure", 3, 10, null, null },
                    { 13, "Mechelen", "België", "2800", "Spuibeekstraat", 4, 11, null, null },
                    { 14, "Duffel", "België", "2570", "Beukheuvel", 20, 12, null, null },
                    { 15, "Kortrijk", "België", "8500", "Nijverheidskaai", 13, 13, null, null },
                    { 4, "Gent", "België", "9000", "Zebrastraat", 36, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventInfoId", "Status", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 19, 19, 2, 7, 5 },
                    { 18, 18, 2, 7, 5 },
                    { 17, 17, 2, 7, 5 },
                    { 16, 16, 4, 7, 5 },
                    { 15, 15, 2, 7, 5 },
                    { 14, 14, 0, 7, 5 },
                    { 20, 20, 2, 7, 5 },
                    { 10, 10, 0, 9, 3 },
                    { 12, 12, 4, 9, 3 },
                    { 11, 11, 0, 9, 3 },
                    { 9, 9, 0, 7, 2 },
                    { 8, 8, 0, 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventInfoId", "Status", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 7, 7, 0, 7, 2 },
                    { 6, 6, 2, 7, 2 },
                    { 5, 5, 2, 7, 2 },
                    { 3, 3, 0, 1, 1 },
                    { 2, 2, 0, 1, 1 },
                    { 1, 1, 0, 1, 1 },
                    { 13, 13, 0, 8, 4 },
                    { 4, 4, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateOfPurchase", "EventId", "TicketCustomerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 12, 11, 58, 54, 160, DateTimeKind.Local).AddTicks(3113), 1, 1 },
                    { 2, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3050), 1, 1 },
                    { 3, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3090), 1, 1 },
                    { 4, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3096), 1, 1 },
                    { 5, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3099), 1, 1 },
                    { 6, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3102), 1, 2 },
                    { 7, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3105), 1, 2 },
                    { 8, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3109), 1, 3 },
                    { 9, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3112), 1, 3 },
                    { 10, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3116), 1, 3 },
                    { 11, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3122), 1, 3 },
                    { 12, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3125), 1, 4 },
                    { 13, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3128), 1, 4 },
                    { 14, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3133), 1, 5 },
                    { 15, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3136), 1, 5 },
                    { 16, new DateTime(2021, 6, 12, 11, 58, 54, 162, DateTimeKind.Local).AddTicks(3140), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "Category", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, "zitplaats", 1, 1 },
                    { 2, "zitplaats", 1, 2 },
                    { 3, "zitplaats", 1, 3 },
                    { 4, "zitplaats", 1, 4 },
                    { 5, "zitplaats", 1, 5 },
                    { 6, "zitplaats", 1, 6 },
                    { 7, "zitplaats", 1, 7 },
                    { 8, "zitplaats", 1, 8 },
                    { 9, "zitplaats", 1, 9 },
                    { 10, "zitplaats", 1, 10 },
                    { 11, "zitplaats", 1, 11 },
                    { 12, "zitplaats", 1, 12 },
                    { 13, "zitplaats", 1, 13 },
                    { 14, "zitplaats", 1, 14 },
                    { 15, "zitplaats", 1, 15 },
                    { 16, "zitplaats", 1, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TicketCustomerId",
                table: "Addresses",
                column: "TicketCustomerId",
                unique: true,
                filter: "[TicketCustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TicketProviderId",
                table: "Addresses",
                column: "TicketProviderId",
                unique: true,
                filter: "[TicketProviderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_VenueId",
                table: "Addresses",
                column: "VenueId",
                unique: true,
                filter: "[VenueId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventInfoId",
                table: "Events",
                column: "EventInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TicketProviderId",
                table: "Events",
                column: "TicketProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPrices_TicketId",
                table: "TicketPrices",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCustomerId",
                table: "Tickets",
                column: "TicketCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "TicketPrices");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "TicketCustomers");

            migrationBuilder.DropTable(
                name: "EventInfo");

            migrationBuilder.DropTable(
                name: "TicketProviders");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
