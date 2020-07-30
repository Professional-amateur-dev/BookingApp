using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class RoomSeeder
    {
        public static void SeedRoom(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Price = 123.4,
                    RoomTypeId = 1
                },
                new Room
                {
                    Id = 2,
                    Price = 134.7,
                    RoomTypeId = 2
                },
                new Room
                {
                    Id = 3,
                    Price = 23.8,
                    RoomTypeId = 3
                }
            );
        }
    }
}