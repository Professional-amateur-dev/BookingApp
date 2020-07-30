using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class BookingSeeder
    {
        public static void SeedBooking(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BeginningDate= new System.DateTime(2005,2,10),
                    EndingDate= new System.DateTime(2005,2,20),
                    GuestId = 1,
                    BookingStatusId = 1,
                    RoomId = 1
                },
                new Booking
                {
                    Id = 2,
                    BeginningDate= new System.DateTime(2005,3,10),
                    EndingDate= new System.DateTime(2005,3,20),
                    GuestId = 2,
                    BookingStatusId = 2,
                    RoomId = 2
                },
                new Booking
                {
                    Id = 3,
                    BeginningDate= new System.DateTime(2020,2,10),
                    EndingDate= new System.DateTime(2023,6,20),
                    GuestId = 1,
                    BookingStatusId = 2,
                    RoomId = 1
                }
            );
        }
    }
}