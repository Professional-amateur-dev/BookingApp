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
                    Type = "Deluxe spavaca sobe 1",
                    Description = "dugacak opis sobe",
                    BedCount = 3,
                    PersonCount = 6,
                    Surface = 58
                },
                new RoomType
                {
                    Id = 2,
                    Type = "Basic spavaca sobe 2",
                    Description = "dugacak opis sobe 2",
                    BedCount = 1,
                    PersonCount = 2,
                    Surface = 30
                },
                new RoomType
                {
                    Id = 3,
                    Type = "Deluxe spavaca soba 3",
                    Description = "dugacak opis sobe 3",
                    BedCount = 15,
                    PersonCount = 30,
                    Surface = 90
                },
                new RoomType
                {
                    Id = 4,
                    Type = "Deluxe spavaca soba 4",
                    Description = "dugacak opis sobe 4",
                    BedCount = 3,
                    PersonCount = 9,
                    Surface = 170
                }
            );
        }
    }
}