using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class RoomStatusSeeder
    {
        public static void SeedRoomService(this ModelBuilder modelBuilder){
            
             modelBuilder.Entity<RoomService>().HasData(
                new RoomService
                {
                    Id = 1,
                    Name = "WIFI",
                    Price = 25.4
                },
                new RoomService
                {
                    Id = 2,
                    Name = "Topla voda",
                    Price = 84.23
                },
                new RoomService
                {
                    Id = 3,
                    Name = "Parking",
                    Price = 569.23
                },
                new RoomService
                {
                    Id = 4,
                    Name = "Sat TV",
                    Price = 0.23
                },
                new RoomService
                {
                    Id = 5,
                    Name = "Dorucak",
                    Price = 59.23
                },
                new RoomService
                {
                    Id = 6,
                    Name = "ekstra rucnici",
                    Price = 67.23
                }
            );
        }
    }
}