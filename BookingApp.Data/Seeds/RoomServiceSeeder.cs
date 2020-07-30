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
                }
            );
        }
    }
}