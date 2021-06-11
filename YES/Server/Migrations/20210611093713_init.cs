using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YES.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    NameProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
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
                name: "EventInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxAvailableTickets = table.Column<int>(type: "int", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventInfo_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
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
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                table: "TicketCustomers",
                columns: new[] { "Id", "BankAccount", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "BE68 5390 0754 7034", "kobe@mail.com", "Kobe", "Delobelle", "0473 288 888" },
                    { 16, "BE88 4785 9785 9620", "Victor@mail.com", "Victor", "De Putte", "0488 754 752" },
                    { 15, "BE69 2467 0468 0478", "Noah@mail.com", "Noah", "Vanarke", "0475 850 852" },
                    { 14, "BE86 4576 0445 4873", "Arthur@mail.com", "Arthur", "Vangeest", "0490 785 457" },
                    { 13, "BE72 0145 7857 6375", "Kurt@mail.com", "Kurt", "Debolle", "0478 140 349" },
                    { 12, "BE58 7520 4778 8214", "Emir@mail.com", "Emir", "Öztürk", "0473 478 795" },
                    { 11, "BE89 4785 2015 3065", "Mohamed@mail.com", "Mohamed", "Yilmaz", "0472 752 785" },
                    { 9, "BE86 7831 5701 5684", "Alice@mail.com", "Alice", "Mcgregor", "0478 785 125" },
                    { 10, "BE68 4578 3025 7304", "Louise@mail.com", "Louise", "Degroote", "0477 765 782" },
                    { 7, "BE96 4278 6420 5496", "Olivia@mail.com", "Olivia", "Goossens", "0478 687 138" },
                    { 6, "BE41 7563 7835 0157", "Dries@mail.com", "Dries", "Maes", "0432 457 896" },
                    { 5, "BE77 7893 0824 7304", "Nick@mail.com", "Nick", "Angularlover", "0478 365 852" },
                    { 4, "BE70 5560 1278 7078", "Seba@mail.com", "Seba", "Stiaan", "0485 345 349" },
                    { 3, "BE60 5590 0994 7021", "Pieter@mail.com", "Pieter", "Corp", "0453 288 888" },
                    { 2, "BE68 6990 5800 7574", "ward@mail.com", "Ward", "Impe", "0473 422 458" },
                    { 8, "BE77 1046 8642 5676", "Mila@mail.com", "Mila", "Vandevoorde", "0485 377 352" }
                });

            migrationBuilder.InsertData(
                table: "TicketProviders",
                columns: new[] { "Id", "BankAccount", "Email", "NameProvider", "PhoneNumber" },
                values: new object[,]
                {
                    { 7, "BE78 6872 3968 7821", "info@sportpaleisgroup.be", "Sportpaleis Group NV", "09 879 87 74" },
                    { 9, "BE55 4752 7836 4878", "info@trix.be", "Team Trix", "09 456 79 17" },
                    { 8, "BE55 7865 7874 1237", "info@elixir.be", "eLiXir", "09 782 71 42" },
                    { 6, "BE55 7865 7874 1237", "info@extremaoutdoor.be", "Extrema", "09 485 35 41" },
                    { 2, "BE78 7854 3585 7820", "info@tomorrowland.be", "WAREONE.world bvba", "09 147 27 78" },
                    { 4, "BE76 5455 8725 7824", "info@couleurcafe.be", "Couleur Cafe", "09 785 24 86" },
                    { 3, "BE78 7768 3578 1220", "info@rockwerchter.be", "Live Nation Festivals NV", "09 754 87 78" },
                    { 1, "BE78 3590 0754 7674", "info@vooruit.be", "Vooruit", "09 267 28 20" },
                    { 5, "BE34 8792 4687 2565", "info@pukkelpop.be", "Chokri Mahassine", "09 765 78 86" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 9, 100000, "Pukkelpop" },
                    { 1, 1110, "Kunstencentrum Vooruit" },
                    { 2, 2000, "Capitole Gent" },
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
                    { 25, "Brussel", "België", "1020", "Eeuwfeestlaan", 617, null, 4, 8 },
                    { 24, "Werchter", "België", "3118", "Festivalpark", null, null, null, 7 },
                    { 23, "Boom", "België", "2850", "Schommelei", 1, null, null, 6 },
                    { 22, "Antwerpen", "België", "2170", "Schijnpoortweg", 119, null, 7, 5 },
                    { 21, "Gent", "België", "9000", "Overpoortstraat", 60, null, 8, 4 },
                    { 20, "Antwerpen", "België", "2140", "Noordersingel", 28, null, 9, 3 },
                    { 19, "Gent", "België", "9000", "Graaf Van Vlaanderenplein", 5, null, null, 2 },
                    { 1, "Gent", "België", "9000", "Sint-Pietersnieuwstraat", 23, null, 1, 1 },
                    { 31, "Antwerpen", "België", "2000", "Braziliestraat", 26, null, 6, null },
                    { 30, "Hasselt", "België", "3510", "Koorstraat", 17, null, 5, null },
                    { 29, "Mechelen", "België", "2800", "Blarenberglaan", 3, null, 3, null },
                    { 26, "Hasselt", "België", "3500", "Kempische Steenweg", null, null, null, 9 },
                    { 18, "Oostende", "België", "8400", "Stapelhuisstraat", 17, 16, null, null },
                    { 28, "Antwerpen", "België", "6200", "Korte Vlierstraat", 6, null, 2, null },
                    { 16, "Wevelgem", "België", "8560", "Hondsschotestraat", 83, 14, null, null },
                    { 3, "Gent", "België", "9000", "Leeuwstraat", 7, 2, null, null },
                    { 4, "Gent", "België", "9000", "Zebrastraat", 36, 3, null, null },
                    { 5, "Gent", "België", "9000", "Tijgerstraat", 24, 4, null, null },
                    { 6, "Sint-Niklaas", "België", "9100", "Apostelstraat", 79, 5, null, null },
                    { 7, "Gent", "België", "9000", "Olifantstraat", 26, 6, null, null },
                    { 8, "Gent", "België", "9000", "Olifantstraat", 2, 7, null, null },
                    { 9, "Sint-Joost-ten-Node", "België", "1210", "Kleine Dalstraat", 1, 8, null, null },
                    { 17, "Ieper", "België", "8900", "Tybaertstraat", 27, 15, null, null },
                    { 27, "Houthalen-Helchteren", "België", "3530", "Binnenvaartstraat", null, null, null, 10 },
                    { 11, "Etterbeek", "België", "1040", "Waversesteenweg", 100, 9, null, null },
                    { 12, "Waver", "België", "1300", "Rue de la Cure", 3, 10, null, null },
                    { 13, "Mechelen", "België", "2800", "Spuibeekstraat", 4, 11, null, null },
                    { 14, "Duffel", "België", "2570", "Beukheuvel", 20, 12, null, null },
                    { 15, "Kortrijk", "België", "8500", "Nijverheidskaai", 13, 13, null, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Status", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 2, 0, 1, 1 },
                    { 1, 0, 1, 1 },
                    { 3, 0, 1, 1 },
                    { 4, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "EventInfo",
                columns: new[] { "Id", "BannerImgUrl", "Description", "EventDate", "EventId", "MaxAvailableTickets", "Name", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, null, "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 500, "EK België-Rusland", "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm" },
                    { 2, null, "Uitzending EK wedstrijd tussen België en Denemarken, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 500, "EK België-Denemarken", null },
                    { 3, null, "Uitzending EK wedstrijd tussen België en Finland, wees er tijdig bij want door corona zijn de plaatsen beperkt", new DateTime(2021, 6, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, 500, "EK België-Finland", null },
                    { 4, "https://www.vooruit.be/cms_files/system/images/img11483_174.jpg", "Wees er tijdig bij want door corona zijn de plaatsen beperkt", null, 4, 50, "UITGESTELD: Terras Sessie: Joni Sheila", "https://www.vooruit.be/nl/agenda/3771//TERRAS_SESSIE_10_Joni_Sheila" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateOfPurchase", "EventId", "TicketCustomerId" },
                values: new object[,]
                {
                    { 4, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5465), 1, 1 },
                    { 5, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5468), 1, 1 },
                    { 6, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5471), 1, 2 },
                    { 7, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5474), 1, 2 },
                    { 8, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5477), 1, 3 },
                    { 2, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5426), 1, 1 },
                    { 10, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5483), 1, 3 },
                    { 11, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5486), 1, 3 },
                    { 12, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5488), 1, 4 },
                    { 13, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5491), 1, 4 },
                    { 14, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5494), 1, 5 },
                    { 15, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5497), 1, 5 },
                    { 16, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5500), 1, 5 },
                    { 1, new DateTime(2021, 6, 11, 11, 37, 12, 623, DateTimeKind.Local).AddTicks(5985), 1, 1 },
                    { 3, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5459), 1, 1 },
                    { 9, new DateTime(2021, 6, 11, 11, 37, 12, 625, DateTimeKind.Local).AddTicks(5480), 1, 3 }
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
                name: "IX_EventInfo_EventId",
                table: "EventInfo",
                column: "EventId",
                unique: true);

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
                name: "EventInfo");

            migrationBuilder.DropTable(
                name: "TicketPrices");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "TicketCustomers");

            migrationBuilder.DropTable(
                name: "TicketProviders");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
