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
                    { 31, "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg", "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", new DateTime(2021, 9, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), 31, 75000, "Pukkelpop (Day 3)", "https://www.pukkelpop.be/en/" },
                    { 32, "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg", "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", new DateTime(2021, 9, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 32, 75000, "Pukkelpop (Day 4)", "https://www.pukkelpop.be/en/" },
                    { 33, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/162265388_3896238790437215_4033182633678490037_n.jpg?_nc_cat=102&ccb=1-3&_nc_sid=340051&_nc_ohc=NJa6V9eplsUAX9HsJnM&_nc_ht=scontent-bru2-1.xx&oh=3194a5fb0274bb9d1bfd2979a66d43c5&oe=60C9D8E1", "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", new DateTime(2021, 9, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), 33, 60000, "Extrema Outdoor Extra: September edition (Day 1)", "https://extrema.be" },
                    { 34, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/162265388_3896238790437215_4033182633678490037_n.jpg?_nc_cat=102&ccb=1-3&_nc_sid=340051&_nc_ohc=NJa6V9eplsUAX9HsJnM&_nc_ht=scontent-bru2-1.xx&oh=3194a5fb0274bb9d1bfd2979a66d43c5&oe=60C9D8E1", "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", new DateTime(2021, 9, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 34, 60000, "Extrema Outdoor Extra: September edition (Day 2)", "https://extrema.be" },
                    { 35, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/162265388_3896238790437215_4033182633678490037_n.jpg?_nc_cat=102&ccb=1-3&_nc_sid=340051&_nc_ohc=NJa6V9eplsUAX9HsJnM&_nc_ht=scontent-bru2-1.xx&oh=3194a5fb0274bb9d1bfd2979a66d43c5&oe=60C9D8E1", "Extrema Outdoor Extra is our scalable edition in September. This new edition will allow us to be more flexible than a festival at full power. We want to fully take advantage of any opportunity we get and our team is working diligently to bring us all together on a dance floor sooner rather than later.", new DateTime(2021, 9, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 35, 60000, "Extrema Outdoor Extra: September edition (Day 3)", "https://extrema.be" },
                    { 36, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 36, 2500, "Balthazar + Sohnarr | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 37, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 37, 2500, "Goose | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 38, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 38, 2500, "Arsenal + Tin Fingers | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 39, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 39, 2500, "Lil Kleine + Ronnie Flex & The Fam | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 40, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), 40, 2500, "Bazart + Yong Yello | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 41, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 9, 20, 0, 0, 0, DateTimeKind.Unspecified), 41, 2500, "Gabriel Rios + Eefje De Visser + Emmy D'Arc | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 42, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), 42, 2500, "Bart Peeters & De Ideale Mannen | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 43, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), 43, 2500, "Tourist LeMC | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 44, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 44, 2500, "Goose + Glints | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 45, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 45, 2500, "Blackwave. + Charles + Emma Bale ", "https://www.rockwerchter.be/nl/" },
                    { 47, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), 47, 2500, "Regi Live + Cleymans & Van Geel | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 48, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 48, 2500, "Jasper Steverlinck + Portland | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 49, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 49, 2500, "Alex Agnew | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 50, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 50, 2500, "Zwangere Guy + Miss Angel + Chibi Ichigo | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 51, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), 51, 2500, "Whispering Sons + Millionaire | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 52, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), 52, 2500, "Snelle & De Lieve Jongens Band | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 53, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 53, 2500, "Bart Peters & De Ideale Mannen | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 54, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), 54, 2500, "Selah Sue + Meskerem Mees + TheColorGrey + Sam De Neef | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 55, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 31, 21, 0, 0, 0, DateTimeKind.Unspecified), 55, 2500, "Niels Destadsbader | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 56, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 9, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 56, 2500, "Black Box Revelation + Brutus + Equal Idiots + Stake + KillTheLogo | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 30, "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg", "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", new DateTime(2021, 9, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 30, 75000, "Pukkelpop (Day 2)", "https://www.pukkelpop.be/en/" },
                    { 29, "https://www.pukkelpop.be/assets/default/dist/images/PKP21-logo.e121aecf.svg", "Pukkelpop selects a musical line-up with an alternative fringe.  Almost 200 current musical sensations, living legends and visionary alternative artists all come to perform on one of our many stages. Pukkelpop opens up a world of possibilities, from hi-octane rock to low-fi singer-songwriters, bright splashes of pure pop to banging house and hot metal. Petit Bazar and Salon Fou usher in street theatre, entertainment and well-being in all senses of the word. Food Wood serves up dishes from around the world whereas Baraque Futur focuses on sustainability.", new DateTime(2021, 9, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), 29, 75000, "Pukkelpop (Day 1)", "https://www.pukkelpop.be/en/" },
                    { 46, "https://s1.ticketm.net/img/tat/dam/a/1b9/c2033d50-a83a-4163-b9da-441c5aa7d1b9_1434371_CUSTOM.jpg", "Vanaf 1 juli tot 1 augustus in het Festivalpark: WERCHTER PARKLIFE.  Eén maand lang, vier dagen per week de beste concerten in een tijdelijke openlucht-arena in het Festivalpark. Per show kunnen er tot 2.500 fans coronaveilig genieten van hun favoriete artiesten.", new DateTime(2021, 8, 17, 20, 0, 0, 0, DateTimeKind.Unspecified), 46, 2500, "De Mens + Ruben Block | Werchter Parklife", "https://www.rockwerchter.be/nl/" },
                    { 27, "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg", "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", new DateTime(2021, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), 27, 200000, "Tomorrowland (Weekend 2: Day 2)", "https://www.tomorrowland.com/en/festival/welcome" },
                    { 28, "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg", "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", new DateTime(2021, 9, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 28, 200000, "Tomorrowland (Weekend 2: Day 3)", "https://www.tomorrowland.com/en/festival/welcome" },
                    { 2, "https://www.vooruit.be/cms_files/system/images/img11659_174.jpg", "Uitzending EK wedstrijd tussen België en Denemarken, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 500, "EK België-Denemarken", "https://www.vooruit.be/nl/agenda/3839//EK_Denemarken_Belgie_op_groot_scherm_" },
                    { 3, "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg", "Uitzending EK wedstrijd tussen België en Finland, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, 500, "EK België-Finland", "https://www.vooruit.be/nl/agenda/3841//EK_Finland_Belgie_op_groot_scherm" },
                    { 4, "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg", "Wees er tijdig bij want door corona zijn de plaatsen beperkt", null, 4, 50, "Terras Sessie: Joni Sheila", "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila" },
                    { 5, "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg", "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", new DateTime(2021, 7, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 5, 1000, "Kommil Foo", "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo" },
                    { 6, "http://static.sportpaleisgroep.be/sportpaleis/img/events/2791/b221696a05bb3ce32d2748f7734efaeac6f0e44c/billboard.jpg", "Een piano, een gitaar, een viool en hun 2 karakterstemmen: meer hebben de broers Walschaerts niet nodig om hun publiek een memorabele avond te bezorgen. Dertig jaar onafgebroken maken en spelen.Hoog tijd dus om uit al dat moois een nieuwe voorstelling te destilleren. Zonder circus, intiem. Raf, Mich, hun mooiste liedjes en hun strafste verhalen. Kommil Foo op z’n best!", new DateTime(2021, 7, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, 1000, "Kommil Foo", "http://www.capitole-gent.be/nl/kalender/2020-2021/kommil-foo" },
                    { 7, "http://static.sportpaleisgroep.be/sportpaleis/img/events/2946/58d62f6c31062dda0be21c3983929ea88d9fb007/billboard.jpg", "De gloednieuwe, 11e solovoorstelling van de Schotse internationale comedy superster komt, vlak na zijn baanbrekende wereldsucces ‘Daniel Sloss: X’, naar Capitole Gent en Stadsschouwburg Antwerpen.", new DateTime(2021, 10, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 7, 2000, "Daniel Sloss", "http://www.capitole-gent.be/nl/kalender/2021-2022/daniel-sloss" },
                    { 8, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg", "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", new DateTime(2021, 9, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, 1000, "An Evening with Alex Agnew", "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew" },
                    { 9, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2641/cd1db8d0178c3381b07c6f9691965af3d3591763/billboard.jpg", "De wereld is klaar voor een nieuwe start, zo ook Alex Agnew. Tijdens BCWYWF was er al de #MeToo, het genderdebat, maar plots was daar een virus, Black Lives Matter, en waar zijn die klimaatactivisten naartoe? Benieuwd wat Alex Agnew over deze en nog tal van andere onderwerpen te vertellen heeft?", new DateTime(2021, 9, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, 1000, "An Evening with Alex Agnew", "http://www.capitole-gent.be/nl/kalender/2021-2022/an-evening-with-alex-agnew" },
                    { 10, "https://www.trixonline.be/images/events/detail/liligrace-web.png", "Lili Grace, dat zijn de zussen Nelle en Dienne, en zij doen ongemeen boeiende dingen met twee stemmen, cello, keyboards en electronica. Met hun dark-pop haalden ze in 2012 de finale van Humo's Rock Rally en deden ze voorprogramma's voor onder meer Trentemøller, CocoRosie en Nils Frahm.", new DateTime(2021, 6, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), 10, 50, "Lili Grace / Rooftop Concert", "https://www.trixonline.be/nl/programma/lili-grace/2756/" },
                    { 12, "https://www.trixonline.be/images/lightbox/the-armedall-eight.jpg", "Dit concert is afgelast. Alle tickets worden automatisch terugbetaald.", new DateTime(2021, 10, 18, 19, 30, 0, 0, DateTimeKind.Unspecified), 12, 500, "The Armed", "https://www.trixonline.be/nl/programma/the-armed/2723/" },
                    { 13, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/68947152_10156578134447644_7759879836461432832_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=IDm1dnxmhosAX-EYdU6&_nc_ht=scontent-bru2-1.xx&oh=18d225698aa70604374adbaf32077950&oe=60CA125B", "VJ Ward in the Mix", new DateTime(2021, 9, 10, 1, 0, 0, 0, DateTimeKind.Unspecified), 13, 100, "VJ Ward", "https://www.facebook.com/Dj.Ward.Impe/" }
                });

            migrationBuilder.InsertData(
                table: "EventInfo",
                columns: new[] { "Id", "BannerImgUrl", "Description", "EventDate", "EventId", "MaxAvailableTickets", "Name", "WebsiteUrl" },
                values: new object[,]
                {
                    { 11, "https://www.trixonline.be/images/lightbox/15070028-min-scaled.jpg", "Donkere, hypnotiserende pop uit de UK. Meng The Killers met U2 en je krijgt een soort beschrijving van hun sound (StuBru)", new DateTime(2021, 9, 25, 19, 30, 0, 0, DateTimeKind.Unspecified), 11, 500, "The Howl And The Hum", "https://www.trixonline.be/nl/programma/the-howl-and-the-hum/2713/" },
                    { 15, "https://static.sportpaleisgroep.be/sportpaleis/img/events/3055/2bc5d811ace73d22a3f95f204665a66dfcbfd756/billboard.jpg", "Alicia Keys is terug. En hoe! Het muziekicoon met 15 GRAMMY-prijzen op haar naam kondigt vandaag haar nieuwe album ‘ALICIA’ aan met release voorzien op 20 maart bij Sony Music, en haar langverwachte terugkeer naar de podia met haar ‘ALICIA – THE WORLD TOUR’.", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 10000, "Alicia Keys: The World Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/alicia-keys" },
                    { 26, "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg", "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", new DateTime(2021, 9, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 26, 200000, "Tomorrowland (Weekend 2: Day 1)", "https://www.tomorrowland.com/en/festival/welcome" },
                    { 25, "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg", "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", new DateTime(2021, 8, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), 25, 200000, "Tomorrowland (Weekend 1: Day 3)", "https://www.tomorrowland.com/en/festival/welcome" },
                    { 24, "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg", "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", new DateTime(2021, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 24, 200000, "Tomorrowland (Weekend 1: Day 2)", "https://www.tomorrowland.com/en/festival/welcome" },
                    { 14, "https://scontent-bru2-1.xx.fbcdn.net/v/t1.6435-9/68947152_10156578134447644_7759879836461432832_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=IDm1dnxmhosAX-EYdU6&_nc_ht=scontent-bru2-1.xx&oh=18d225698aa70604374adbaf32077950&oe=60CA125B", "Na lang anticiperen krijgt VJ Ward een kans zich op het grote podium te bewijzen. Dit jonge talent draait overal de pannen van het dak, mis deze kans dus niet want de plaatsen zijn beperkt.", new DateTime(2021, 10, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), 14, 10000, "VJ Ward / eLiXir on Tour", "https://www.facebook.com/Dj.Ward.Impe/" },
                    { 22, "http://static.sportpaleisgroep.be/sportpaleis/img/events/3019/71b8033e72484c9da1555c70d71d48567f708f87/banner.jpg", "Het is nú al uitkijken naar het najaar, want Tomorrowland en Dimitri Vegas & Like Mike toveren het Antwerps Sportpaleis opnieuw om tot een magisch indoorfestival. Daarvoor halen ze alles uit de kast: het beloven (voor de achtste keer al!) twee waanzinnig spectaculaire avonden te worden met de grootste hits maar ook heel wat nieuwe muziek én een vleugje Tomorrowland magie.", new DateTime(2021, 12, 18, 19, 30, 0, 0, DateTimeKind.Unspecified), 22, 23359, "Tomorrowland presents: Dimitri Vegas & Like Mike Garden of Madness", "https://www.sportpaleis.be/nl/kalender/2021-2022/tomorrowland-presents-dimitri-vegas--like-mike" },
                    { 21, "http://static.sportpaleisgroep.be/sportpaleis/img/events/3019/71b8033e72484c9da1555c70d71d48567f708f87/banner.jpg", "Het is nú al uitkijken naar het najaar, want Tomorrowland en Dimitri Vegas & Like Mike toveren het Antwerps Sportpaleis opnieuw om tot een magisch indoorfestival. Daarvoor halen ze alles uit de kast: het beloven (voor de achtste keer al!) twee waanzinnig spectaculaire avonden te worden met de grootste hits maar ook heel wat nieuwe muziek én een vleugje Tomorrowland magie.", new DateTime(2021, 12, 17, 19, 30, 0, 0, DateTimeKind.Unspecified), 21, 23359, "Tomorrowland presents: Dimitri Vegas & Like Mike Garden of Madness", "https://www.sportpaleis.be/nl/kalender/2021-2022/tomorrowland-presents-dimitri-vegas--like-mike" },
                    { 23, "https://www.tomorrowland.com/src/Frontend/Themes/tomorrowland/Core/Layout/images/opengraph/tomorrowland.jpg", "Live Today, Love Tomorrow, Unite Forever: In the coming months, the line-up for Tomorrowland 2021 will be announced.", new DateTime(2021, 8, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), 23, 200000, "Tomorrowland (Weekend 1: Day 1)", "https://www.tomorrowland.com/en/festival/welcome" },
                    { 19, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg", "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", new DateTime(2021, 10, 16, 19, 30, 0, 0, DateTimeKind.Unspecified), 19, 10000, "Elton John: Farewell Yellow Brick Road Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john" },
                    { 18, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg", "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", new DateTime(2022, 9, 29, 19, 30, 0, 0, DateTimeKind.Unspecified), 18, 23359, "The Weeknd: The After Hours Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd" },
                    { 17, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2823/45f44ec618c946e96d38606d854a45af415c9b26/billboard.jpg", "The Weeknd kondigt met ‘The After Hours Tour’ zijn nieuwe wereldtournee aan die op 11 juni in de VS van start gaat en in het najaar de oversteek naar Europa maakt. De tour volgt op de release van zijn nieuwe album ‘After Hours’ op 20 maart met singles “Heartless”, de oorwurm “Blinding Lights” en nieuw sinds gisteren de single “After Hours”.", new DateTime(2022, 9, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), 17, 23359, "The Weeknd: The After Hours Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/the-weeknd" },
                    { 16, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2813/4bd008b389321af80580493d3cb77243d46546b3/billboard.jpg", "Als gevolg van de pandemie had Iron Maiden zijn ‘Legacy of the Beast Tour 2020’ verplaatst naar juni/juli 2021. Normaal zou de band op zondag 27 juni 2021 een headlineshow spelen in het Antwerps Sportpaleis. Helaas moet de tour weer met een jaar verschoven worden. Maar niet getreurd, de band staat in 2022 opnieuw op Graspop Metal Meeting om het beste van zichzelf te geven!", new DateTime(2021, 6, 27, 19, 30, 0, 0, DateTimeKind.Unspecified), 16, 10000, "Iron Maiden: Legacy Of The Beast Tour", "https://www.sportpaleis.be/nl/kalender/2020-2021/iron-maiden" },
                    { 20, "https://static.sportpaleisgroep.be/sportpaleis/img/events/2601/99508cf61898ece9332fcd6896bc1d5dbc840061/billboard.jpg", "Na lang beraad heeft Elton John tot zijn grote spijt besloten om de Europese tourdata van zijn “Farewell Yellow Brick Road Tour” te verplaatsen, alsook de twee concerten gepland in Sportpaleis Antwerpen. Deze moeilijke beslissing is gemaakt om de veiligheid en gezondheid van zijn fans te garanderen. Elton John kijkt ernaar uit om terug te spelen voor zijn trouwe fans over de hele wereld en bedankt iedereen voor het begrip.", new DateTime(2021, 10, 17, 19, 30, 0, 0, DateTimeKind.Unspecified), 20, 10000, "Elton John: Farewell Yellow Brick Road Tour", "https://www.sportpaleis.be/nl/kalender/2021-2022/elton-john" }
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
                    { 4, 0, "BE70 5560 1278 7078", "Seba@mail.com", "Seba", "Stiaan", "0485 345 349" },
                    { 7, 0, "BE96 4278 6420 5496", "Olivia@mail.com", "Olivia", "Goossens", "0478 687 138" },
                    { 6, 0, "BE41 7563 7835 0157", "Dries@mail.com", "Dries", "Maes", "0432 457 896" },
                    { 5, 0, "BE77 7893 0824 7304", "Nick@mail.com", "Nick", "Angularlover", "0478 365 852" },
                    { 3, 0, "BE60 5590 0994 7021", "Pieter@mail.com", "Pieter", "Corp", "0453 288 888" },
                    { 2, 0, "BE68 6990 5800 7574", "ward@mail.com", "Ward", "Impe", "0473 422 458" },
                    { 1, 0, "BE68 5390 0754 7034", "kobe@mail.com", "Kobe", "Delobelle", "0473 288 888" },
                    { 8, 0, "BE77 1046 8642 5676", "Mila@mail.com", "Mila", "Vandevoorde", "0485 377 352" }
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
                    { 3, 0, "BE78 7768 3578 1220", "info@rockwerchter.be", "Live Nation Festivals NV", "09 754 87 78" },
                    { 2, 0, "BE78 7854 3585 7820", "info@tomorrowland.be", "WAREONE.world bvba", "09 147 27 78" },
                    { 1, 0, "BE78 3590 0754 7674", "info@vooruit.be", "Vooruit", "09 267 28 20" },
                    { 4, 0, "BE76 5455 8725 7824", "info@couleurcafe.be", "Couleur Cafe", "09 785 24 86" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 9, 100000, "Pukkelpop" },
                    { 1, 1110, "Kunstencentrum Vooruit" },
                    { 2, 2000, "Capitole Gent" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 3, 1500, "Trix" },
                    { 4, 200, "eLiXir Dance & Night Club" },
                    { 5, 23359, "Sportpaleis" },
                    { 6, 200000, "Tomorrowland" },
                    { 7, 100000, "Rock Werchter" },
                    { 8, 60000, "Couleur Café" },
                    { 10, 60000, "Extrema Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber", "TicketCustomerId", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 2, "Gent", "België", "9000", "Tentoonstellingslaan", 1, 1, null, null },
                    { 26, "Hasselt", "België", "3500", "Kempische Steenweg", null, null, null, 9 },
                    { 23, "Boom", "België", "2850", "Schommelei", 1, null, null, 6 },
                    { 22, "Antwerpen", "België", "2170", "Schijnpoortweg", 119, null, 7, 5 },
                    { 21, "Gent", "België", "9000", "Overpoortstraat", 60, null, 8, 4 },
                    { 20, "Antwerpen", "België", "2140", "Noordersingel", 28, null, 9, 3 },
                    { 24, "Werchter", "België", "3118", "Festivalpark", null, null, null, 7 },
                    { 19, "Gent", "België", "9000", "Graaf Van Vlaanderenplein", 5, null, null, 2 },
                    { 27, "Houthalen-Helchteren", "België", "3530", "Binnenvaartstraat", null, null, null, 10 },
                    { 1, "Gent", "België", "9000", "Sint-Pietersnieuwstraat", 23, null, 1, 1 },
                    { 31, "Antwerpen", "België", "2000", "Braziliestraat", 26, null, 6, null },
                    { 30, "Hasselt", "België", "3510", "Koorstraat", 17, null, 5, null },
                    { 29, "Mechelen", "België", "2800", "Blarenberglaan", 3, null, 3, null },
                    { 28, "Antwerpen", "België", "6200", "Korte Vlierstraat", 6, null, 2, null },
                    { 18, "Oostende", "België", "8400", "Stapelhuisstraat", 17, 16, null, null },
                    { 25, "Brussel", "België", "1020", "Eeuwfeestlaan", 617, null, 4, 8 },
                    { 16, "Wevelgem", "België", "8560", "Hondsschotestraat", 83, 14, null, null },
                    { 3, "Gent", "België", "9000", "Leeuwstraat", 7, 2, null, null },
                    { 4, "Gent", "België", "9000", "Zebrastraat", 36, 3, null, null },
                    { 5, "Gent", "België", "9000", "Tijgerstraat", 24, 4, null, null },
                    { 17, "Ieper", "België", "8900", "Tybaertstraat", 27, 15, null, null },
                    { 7, "Gent", "België", "9000", "Olifantstraat", 26, 6, null, null },
                    { 8, "Gent", "België", "9000", "Olifantstraat", 2, 7, null, null },
                    { 9, "Sint-Joost-ten-Node", "België", "1210", "Kleine Dalstraat", 1, 8, null, null },
                    { 6, "Sint-Niklaas", "België", "9100", "Apostelstraat", 79, 5, null, null },
                    { 15, "Kortrijk", "België", "8500", "Nijverheidskaai", 13, 13, null, null },
                    { 11, "Etterbeek", "België", "1040", "Waversesteenweg", 100, 9, null, null },
                    { 14, "Duffel", "België", "2570", "Beukheuvel", 20, 12, null, null },
                    { 12, "Waver", "België", "1300", "Rue de la Cure", 3, 10, null, null },
                    { 13, "Mechelen", "België", "2800", "Spuibeekstraat", 4, 11, null, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventInfoId", "Status", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 56, 56, 0, 3, 9 },
                    { 29, 29, 0, 5, 9 },
                    { 30, 30, 0, 5, 9 },
                    { 31, 31, 0, 5, 9 },
                    { 32, 32, 0, 5, 9 },
                    { 36, 36, 0, 3, 9 },
                    { 37, 37, 0, 3, 9 },
                    { 38, 38, 0, 3, 9 },
                    { 39, 39, 6, 3, 9 },
                    { 40, 40, 0, 3, 9 },
                    { 41, 41, 0, 3, 9 },
                    { 43, 43, 0, 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventInfoId", "Status", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 55, 55, 6, 3, 9 },
                    { 44, 44, 0, 3, 9 },
                    { 45, 45, 0, 3, 9 },
                    { 46, 46, 0, 3, 9 },
                    { 47, 47, 0, 3, 9 },
                    { 48, 48, 0, 3, 9 },
                    { 49, 49, 0, 3, 9 },
                    { 33, 33, 0, 6, 10 },
                    { 50, 50, 6, 3, 9 },
                    { 51, 51, 0, 3, 9 },
                    { 52, 52, 0, 3, 9 },
                    { 54, 54, 0, 3, 9 },
                    { 42, 42, 0, 3, 9 },
                    { 53, 53, 0, 3, 9 },
                    { 18, 18, 2, 7, 5 },
                    { 27, 27, 0, 2, 6 },
                    { 1, 1, 5, 1, 1 },
                    { 2, 2, 0, 1, 1 },
                    { 3, 3, 0, 1, 1 },
                    { 4, 4, 1, 1, 1 },
                    { 5, 5, 2, 7, 2 },
                    { 6, 6, 2, 7, 2 },
                    { 7, 7, 0, 7, 2 },
                    { 8, 8, 0, 7, 2 },
                    { 9, 9, 0, 7, 2 },
                    { 10, 10, 0, 9, 3 },
                    { 11, 11, 0, 9, 3 },
                    { 12, 12, 4, 9, 3 },
                    { 28, 28, 0, 2, 6 },
                    { 13, 13, 6, 8, 4 },
                    { 15, 15, 2, 7, 5 },
                    { 16, 16, 4, 7, 5 },
                    { 17, 17, 2, 7, 5 },
                    { 34, 34, 0, 6, 10 },
                    { 19, 19, 2, 7, 5 },
                    { 20, 20, 2, 7, 5 },
                    { 21, 21, 0, 7, 5 },
                    { 22, 22, 0, 7, 5 },
                    { 23, 23, 0, 2, 6 },
                    { 24, 24, 0, 2, 6 },
                    { 25, 25, 0, 2, 6 },
                    { 26, 26, 0, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventInfoId", "Status", "TicketProviderId", "VenueId" },
                values: new object[] { 14, 14, 3, 7, 5 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventInfoId", "Status", "TicketProviderId", "VenueId" },
                values: new object[] { 35, 35, 0, 6, 10 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateOfPurchase", "EventId", "TicketCustomerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 28, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 5 },
                    { 29, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 5 },
                    { 30, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 5 },
                    { 31, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 6 },
                    { 32, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 7 },
                    { 33, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 8 },
                    { 34, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 8 },
                    { 35, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 9 },
                    { 36, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 9 },
                    { 37, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 10 },
                    { 38, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 11 },
                    { 39, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 12 },
                    { 40, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 12 },
                    { 41, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 13 },
                    { 42, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 13 },
                    { 43, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 13 },
                    { 44, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 14 },
                    { 45, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 15 },
                    { 46, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 16 },
                    { 47, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 16 },
                    { 48, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 16 },
                    { 27, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 5 },
                    { 26, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 4 },
                    { 25, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 4 },
                    { 24, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 3 },
                    { 2, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 4, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 5, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 6, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 7, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 8, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 9, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 10, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 11, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 49, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 16 },
                    { 12, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 14, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 15, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 16, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 17, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateOfPurchase", "EventId", "TicketCustomerId" },
                values: new object[,]
                {
                    { 18, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 19, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 20, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 21, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 3 },
                    { 22, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 3 },
                    { 23, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 3 },
                    { 13, new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 50, new DateTime(2021, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 16 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "Category", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, "zitplaats", 1, 1 },
                    { 28, "VIP", 10, 28 },
                    { 29, "VIP", 10, 29 },
                    { 30, "VIP", 10, 30 },
                    { 31, "regular", 5, 31 },
                    { 32, "regular", 5, 32 },
                    { 33, "regular", 5, 33 },
                    { 34, "regular", 5, 34 },
                    { 35, "regular", 5, 35 },
                    { 36, "regular", 5, 36 },
                    { 37, "regular", 5, 37 },
                    { 38, "regular", 5, 38 },
                    { 39, "regular", 5, 39 },
                    { 40, "regular", 5, 40 },
                    { 41, "regular", 5, 41 },
                    { 42, "regular", 5, 42 },
                    { 43, "regular", 5, 43 },
                    { 44, "regular", 5, 44 },
                    { 45, "regular", 5, 45 },
                    { 46, "regular", 5, 46 },
                    { 47, "regular", 5, 47 },
                    { 48, "regular", 5, 48 },
                    { 27, "VIP", 10, 27 },
                    { 26, "VIP", 10, 26 },
                    { 25, "VIP", 10, 25 },
                    { 24, "VIP", 10, 24 },
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
                    { 49, "regular", 5, 49 },
                    { 12, "zitplaats", 1, 12 },
                    { 14, "zitplaats", 1, 14 },
                    { 15, "zitplaats", 1, 15 },
                    { 16, "zitplaats", 1, 16 },
                    { 17, "VIP", 10, 17 }
                });

            migrationBuilder.InsertData(
                table: "TicketPrices",
                columns: new[] { "Id", "Category", "Price", "TicketId" },
                values: new object[,]
                {
                    { 18, "VIP", 10, 18 },
                    { 19, "VIP", 10, 19 },
                    { 20, "VIP", 10, 20 },
                    { 21, "VIP", 10, 21 },
                    { 22, "VIP", 10, 22 },
                    { 23, "VIP", 10, 23 },
                    { 13, "zitplaats", 1, 13 },
                    { 50, "regular", 5, 50 }
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
