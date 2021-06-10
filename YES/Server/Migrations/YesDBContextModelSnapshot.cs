﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YES.Server;

namespace YES.Server.Migrations
{
    [DbContext(typeof(YesDBContext))]
    partial class YesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YES.Server.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TicketCustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketProviderId")
                        .HasColumnType("int");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketCustomerId")
                        .IsUnique()
                        .HasFilter("[TicketCustomerId] IS NOT NULL");

                    b.HasIndex("TicketProviderId")
                        .IsUnique()
                        .HasFilter("[TicketProviderId] IS NOT NULL");

                    b.HasIndex("VenueId")
                        .IsUnique()
                        .HasFilter("[VenueId] IS NOT NULL");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gent",
                            Country = "België",
                            PostalCode = "9000",
                            Street = "Sint-Pietersnieuwstraat",
                            StreetNumber = 23,
                            TicketProviderId = 1,
                            VenueId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Gent",
                            Country = "België",
                            PostalCode = "9000",
                            Street = "Tentoonstellingslaan",
                            StreetNumber = 1,
                            TicketCustomerId = 1
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TicketProviderId")
                        .HasColumnType("int");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketProviderId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = 0,
                            TicketProviderId = 1,
                            VenueId = 1
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.EventInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BannerImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("MaxAvailableTickets")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("EventInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Uitzending EK openingswedstrijd tussen gastland Rusland en België, wees er tijdig bij want door corona zijn de plaatsen beperkt",
                            EventDate = new DateTime(2021, 6, 12, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EventId = 1,
                            MaxAvailableTickets = 500,
                            Name = "EK België-Rusland",
                            WebsiteUrl = "https://www.vooruit.be/nl/agenda/3837//EK_Belgie_Rusland_op_groot_scherm"
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("TicketCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketCustomerId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfPurchase = new DateTime(2021, 6, 10, 16, 24, 14, 473, DateTimeKind.Local).AddTicks(7397),
                            EventId = 1,
                            TicketCustomerId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateOfPurchase = new DateTime(2021, 6, 10, 16, 24, 14, 475, DateTimeKind.Local).AddTicks(7355),
                            EventId = 1,
                            TicketCustomerId = 1
                        },
                        new
                        {
                            Id = 3,
                            DateOfPurchase = new DateTime(2021, 6, 10, 16, 24, 14, 475, DateTimeKind.Local).AddTicks(7419),
                            EventId = 1,
                            TicketCustomerId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateOfPurchase = new DateTime(2021, 6, 10, 16, 24, 14, 475, DateTimeKind.Local).AddTicks(7425),
                            EventId = 1,
                            TicketCustomerId = 1
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.TicketCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketCustomers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankAccount = "BE68 5390 0754 7034",
                            Email = "kobe@mail.com",
                            FirstName = "Kobe",
                            LastName = "Delobelle",
                            PhoneNumber = "0473 288 888"
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.TicketPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("TicketPrices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "zitplaats",
                            Price = 1,
                            TicketId = 1
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.TicketProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketProviders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankAccount = "BE78 3590 0754 7674",
                            Email = "info@vooruit.be",
                            NameProvider = "Vooruit",
                            PhoneNumber = "09 267 28 20"
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 1200,
                            Name = "Kunstencentrum Vooruit"
                        });
                });

            modelBuilder.Entity("YES.Server.Entities.Address", b =>
                {
                    b.HasOne("YES.Server.Entities.TicketCustomer", "TicketCustomer")
                        .WithOne("Address")
                        .HasForeignKey("YES.Server.Entities.Address", "TicketCustomerId");

                    b.HasOne("YES.Server.Entities.TicketProvider", "TicketProvider")
                        .WithOne("Address")
                        .HasForeignKey("YES.Server.Entities.Address", "TicketProviderId");

                    b.HasOne("YES.Server.Entities.Venue", "Venue")
                        .WithOne("Address")
                        .HasForeignKey("YES.Server.Entities.Address", "VenueId");

                    b.Navigation("TicketCustomer");

                    b.Navigation("TicketProvider");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("YES.Server.Entities.Event", b =>
                {
                    b.HasOne("YES.Server.Entities.TicketProvider", "TicketProvider")
                        .WithMany("Events")
                        .HasForeignKey("TicketProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YES.Server.Entities.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TicketProvider");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("YES.Server.Entities.EventInfo", b =>
                {
                    b.HasOne("YES.Server.Entities.Event", null)
                        .WithOne("EventInfo")
                        .HasForeignKey("YES.Server.Entities.EventInfo", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YES.Server.Entities.Ticket", b =>
                {
                    b.HasOne("YES.Server.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YES.Server.Entities.TicketCustomer", "TicketCustomer")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("TicketCustomer");
                });

            modelBuilder.Entity("YES.Server.Entities.TicketPrice", b =>
                {
                    b.HasOne("YES.Server.Entities.Ticket", "Ticket")
                        .WithOne("TicketPrice")
                        .HasForeignKey("YES.Server.Entities.TicketPrice", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("YES.Server.Entities.Event", b =>
                {
                    b.Navigation("EventInfo");
                });

            modelBuilder.Entity("YES.Server.Entities.Ticket", b =>
                {
                    b.Navigation("TicketPrice");
                });

            modelBuilder.Entity("YES.Server.Entities.TicketCustomer", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("YES.Server.Entities.TicketProvider", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("YES.Server.Entities.Venue", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
