using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class RoomTypeSeeder
    {
        public static void SeedRoomType(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    Id = 1,
                    Type = "Deluxe spavaca sobe",
                    Description = "dugacak opis sobe",
                    BedCount = 3,
                    PersonCount = 6,
                    Surface = 58,
                    RoomServiceId = 1
                },
                new RoomType
                {
                    Id = 2,
                    Type = "Basic spavaca sobe",
                    Description = "dugacak opis sobe 2",
                    BedCount = 1,
                    PersonCount = 2,
                    Surface = 30,
                    RoomServiceId = 1
                },
                new RoomType
                {
                    Id = 3,
                    Type = "Deluxe spavaca soba",
                    Description = "dugacak opis sobe 3",
                    BedCount = 1,
                    PersonCount = 3,
                    Surface = 70,
                    RoomServiceId = 1
                }
            );
        }
    }
}