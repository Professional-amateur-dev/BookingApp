using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class GuestSeeder
    {
        public static void SeedGuest(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<Guest>().HasData(
                new Guest
                {
                    Id = 1,
                    FirstName = "Pero",
                    LastName = "Perić",
                    MobileNumber = "+123456789",
                    Sex = "M",
                    Address = "Adresa 123",
                    City = "Zagreb",
                    State = "Hrvatska"  
                },
                new Guest
                {
                    Id = 2,
                    FirstName = "Ante",
                    LastName = "Antić",
                    MobileNumber = "+987654321",
                    Sex = "M",
                    Address = "Adresa 987",
                    City = "Imotski",
                    State = "Hrvatska"  
                },
                new Guest
                {
                    Id = 3,
                    FirstName = "Chris",
                    LastName = "Brown",
                    MobileNumber = "+12361234",
                    Sex = "Ž",
                    Address = "BTMW 23",
                    City = "Los Angeles",
                    State = "USA"  
                }
            );
        }
    }
}