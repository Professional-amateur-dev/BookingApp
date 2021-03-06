﻿using Microsoft.EntityFrameworkCore;
using BookingApp.Data.Entities;
using BookingApp.Data.Seeds;
using System;

namespace BookingApp.Data.Database
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        public DbSet<RoomService> RoomServices { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<RoomServiceType> RoomServiceTypes {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedBill();
            modelBuilder.SeedBooking();
            modelBuilder.SeedBookingStatus();
            modelBuilder.SeedGuest();
            modelBuilder.SeedPayment();
            modelBuilder.SeedRoom();
            modelBuilder.SeedRoomService();
            modelBuilder.SeedRoomType();
            modelBuilder.SeedUser();
            modelBuilder.SeedRoomServiceType();
        }
    }
}
