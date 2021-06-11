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
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
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
                    { 2, "BE68 6990 5800 7574", "ward@mail.com", "Ward", "Impe", "0473 422 458" },
                    { 3, "BE60 5590 0994 7021", "Pieter@mail.com", "Pieter", "Corp", "0453 288 888" },
                    { 4, "BE70 5560 1278 7078", "Seba@mail.com", "Seba", "Stiaan", "0485 345 349" },
                    { 5, "BE77 7893 0824 7304", "Nick@mail.com", "Nick", "Angularlover", "0478 365 852" }
                });

            migrationBuilder.InsertData(
                table: "TicketProviders",
                columns: new[] { "Id", "BankAccount", "Email", "NameProvider", "PhoneNumber" },
                values: new object[] { 1, "BE78 3590 0754 7674", "info@vooruit.be", "Vooruit", "09 267 28 20" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { 1, 1200, "Kunstencentrum Vooruit" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "Street", "StreetNumber", "TicketCustomerId", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 2, "Gent", "België", "9000", "Tentoonstellingslaan", 1, 1, null, null },
                    { 3, "Gent", "België", "9000", "Leeuwstraat", 7, 2, null, null },
                    { 4, "Gent", "België", "9000", "Zebrastraat", 36, 3, null, null },
                    { 5, "Gent", "België", "9000", "Tijgerstraat", 24, 4, null, null },
                    { 6, "Gent", "België", "9000", "Olifantstraat", 79, 5, null, null },
                    { 1, "Gent", "België", "9000", "Sint-Pietersnieuwstraat", 23, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Status", "TicketProviderId", "VenueId" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 2, 0, 1, 1 },
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
                    { 4, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9736), 1, 1 },
                    { 5, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9739), 1, 1 },
                    { 6, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9742), 1, 2 },
                    { 7, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9745), 1, 2 },
                    { 8, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9748), 1, 3 },
                    { 2, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9669), 1, 1 },
                    { 10, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9754), 1, 3 },
                    { 11, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9757), 1, 3 },
                    { 12, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9760), 1, 4 },
                    { 13, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9763), 1, 4 },
                    { 14, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9766), 1, 5 },
                    { 15, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9769), 1, 5 },
                    { 16, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9772), 1, 5 },
                    { 1, new DateTime(2021, 6, 10, 18, 52, 15, 121, DateTimeKind.Local).AddTicks(5452), 1, 1 },
                    { 3, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9729), 1, 1 },
                    { 9, new DateTime(2021, 6, 10, 18, 52, 15, 124, DateTimeKind.Local).AddTicks(9751), 1, 3 }
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
