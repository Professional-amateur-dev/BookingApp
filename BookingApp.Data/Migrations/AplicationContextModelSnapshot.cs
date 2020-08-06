﻿// <auto-generated />
using System;
using BookingApp.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingApp.Data.Migrations
{
    [DbContext(typeof(AplicationContext))]
    partial class AplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingApp.Data.Entities.Bill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<long>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<long>("PaymentId")
                        .HasColumnType("bigint");

                    b.Property<long>("SalePoint")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Bills");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Amount = 234.0,
                            BookingId = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 413, DateTimeKind.Local).AddTicks(8757),
                            InvoiceDate = new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceDueDate = new DateTime(2005, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceNum = "1/27/123",
                            PaymentId = 1L,
                            SalePoint = 12L,
                            Status = true
                        },
                        new
                        {
                            Id = 2L,
                            Amount = 987.0,
                            BookingId = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 416, DateTimeKind.Local).AddTicks(8405),
                            InvoiceDate = new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceDueDate = new DateTime(2005, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceNum = "1/27/987",
                            PaymentId = 2L,
                            SalePoint = 1L,
                            Status = false
                        },
                        new
                        {
                            Id = 3L,
                            Amount = 19834.0,
                            BookingId = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 416, DateTimeKind.Local).AddTicks(8507),
                            InvoiceDate = new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceDueDate = new DateTime(2005, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceNum = "2/5/987",
                            PaymentId = 2L,
                            SalePoint = 5L,
                            Status = true
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginningDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("BookingStatusId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GuestId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BeginningDate = new DateTime(2005, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingStatusId = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(1501),
                            EndingDate = new DateTime(2005, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 1L,
                            RoomId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            BeginningDate = new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingStatusId = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(2994),
                            EndingDate = new DateTime(2005, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 2L,
                            RoomId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            BeginningDate = new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingStatusId = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(3054),
                            EndingDate = new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GuestId = 1L,
                            RoomId = 1L
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.BookingStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("ValidBooking")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BookingStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(5416),
                            Description = "Booking nikada nije modificiran",
                            Status = "ALL OK BOSS",
                            ValidBooking = true
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(6300),
                            Description = "Bookinga nema, server je u vatri",
                            Status = "FATAL BOOKINNG ERROR",
                            ValidBooking = true
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(6335),
                            Description = "blank description",
                            Status = "ALL OK BOSS 2",
                            ValidBooking = true
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Guest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Adresa 123",
                            City = "Zagreb",
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 418, DateTimeKind.Local).AddTicks(9251),
                            FirstName = "Pero",
                            LastName = "Perić",
                            MobileNumber = "+123456789",
                            Sex = "M",
                            State = "Hrvatska",
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Address = "Adresa 987",
                            City = "Imotski",
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(1125),
                            FirstName = "Ante",
                            LastName = "Antić",
                            MobileNumber = "+987654321",
                            Sex = "M",
                            State = "Hrvatska",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            Address = "BTMW 23",
                            City = "Los Angeles",
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(1195),
                            FirstName = "Chris",
                            LastName = "Brown",
                            MobileNumber = "+12361234",
                            Sex = "Ž",
                            State = "USA",
                            UserId = 3L
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(3556),
                            Description = "opis placanja visom",
                            Status = true,
                            Type = "Visa"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(4350),
                            Description = "placanje nije proslo itd itd",
                            Status = false,
                            Type = "Mastercard"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(4388),
                            Description = "opis placanja visom br 3",
                            Status = true,
                            Type = "Visa"
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("RoomTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(6687),
                            Price = 123.40000000000001,
                            RoomTypeId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(7266),
                            Price = 134.69999999999999,
                            RoomTypeId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(7310),
                            Price = 23.800000000000001,
                            RoomTypeId = 3L
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.RoomService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RoomServices");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 419, DateTimeKind.Local).AddTicks(9766),
                            Name = "WIFI",
                            Price = 25.399999999999999
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(374),
                            Name = "Topla voda",
                            Price = 84.230000000000004
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(404),
                            Name = "Parking",
                            Price = 569.23000000000002
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(407),
                            Name = "Sat TV",
                            Price = 0.23000000000000001
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.RoomType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.Property<long>("RoomServiceId")
                        .HasColumnType("bigint");

                    b.Property<int>("Surface")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RoomServiceId");

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BedCount = 3,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(3016),
                            Description = "dugacak opis sobe",
                            PersonCount = 6,
                            RoomServiceId = 1L,
                            Surface = 58,
                            Type = "Deluxe spavaca sobe"
                        },
                        new
                        {
                            Id = 2L,
                            BedCount = 1,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(4432),
                            Description = "dugacak opis sobe 2",
                            PersonCount = 2,
                            RoomServiceId = 1L,
                            Surface = 30,
                            Type = "Basic spavaca sobe"
                        },
                        new
                        {
                            Id = 3L,
                            BedCount = 1,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(4491),
                            Description = "dugacak opis sobe 3",
                            PersonCount = 3,
                            RoomServiceId = 1L,
                            Surface = 70,
                            Type = "Deluxe spavaca soba"
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(6940),
                            Email = "admin@admin.com",
                            Password = "$%&/(=PŠČŽĐ?)(=?)=(T%RWSR",
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(7721),
                            Email = "biggie@smalls.com",
                            Password = "%EEASTZFGOJOBVTZE%$#&/=(",
                            UserName = "Biggie"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2020, 8, 6, 15, 22, 32, 420, DateTimeKind.Local).AddTicks(7756),
                            Email = "brk@os.com",
                            Password = "E$%#&/%&)=OHFD%/ER()/())PN",
                            UserName = "BrankoKos"
                        });
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Bill", b =>
                {
                    b.HasOne("BookingApp.Data.Entities.Booking", "Booking")
                        .WithMany("Bills")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Data.Entities.Payment", "Payment")
                        .WithMany("Bills")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Booking", b =>
                {
                    b.HasOne("BookingApp.Data.Entities.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Data.Entities.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingApp.Data.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Guest", b =>
                {
                    b.HasOne("BookingApp.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingApp.Data.Entities.Room", b =>
                {
                    b.HasOne("BookingApp.Data.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingApp.Data.Entities.RoomType", b =>
                {
                    b.HasOne("BookingApp.Data.Entities.RoomService", "RoomService")
                        .WithMany("RoomTypes")
                        .HasForeignKey("RoomServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
