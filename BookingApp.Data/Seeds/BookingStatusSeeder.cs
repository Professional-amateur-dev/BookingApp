using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class BookingStatusSeeder
    {
        public static void SeedBookingStatus(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<BookingStatus>().HasData(
                new BookingStatus
                {
                    Id = 1,
                    Status = "ALL OK BOSS",
                    ValidBooking = true,
                    Description = "Booking nikada nije modificiran"
                },
                new BookingStatus
                {
                    Id = 2,
                    Status = "FATAL BOOKINNG ERROR",
                    ValidBooking = true,
                    Description = "Bookinga nema, server je u vatri"
                },
                new BookingStatus
                {
                    Id = 3,
                    Status = "ALL OK BOSS 2",
                    ValidBooking = true,
                    Description = "blank description"
                }
                
            );
        }
    }
}