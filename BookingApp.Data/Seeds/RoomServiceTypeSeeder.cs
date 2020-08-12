using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class RoomServiceTypeSeeder
    {
        public static void SeedRoomServiceType(this ModelBuilder modelBuilder){
            
             modelBuilder.Entity<RoomServiceType>().HasData(
                new RoomServiceType
                {
                    Id=1,
                    RoomServiceId = 1,
                    RoomTypeId = 1
                },
                new RoomServiceType
                {
                    Id=2,
                    RoomServiceId = 1,
                    RoomTypeId = 2
                },new RoomServiceType
                {
                    Id=3,
                    RoomServiceId = 1,
                    RoomTypeId = 3
                },new RoomServiceType
                {
                    Id=4,
                    RoomServiceId = 1,
                    RoomTypeId = 4
                },new RoomServiceType
                {
                    Id=5,
                    RoomServiceId = 1,
                    RoomTypeId = 4
                },new RoomServiceType
                {
                    Id=6,
                    RoomServiceId = 1,
                    RoomTypeId = 4
                },new RoomServiceType
                {
                    Id=7,
                    RoomServiceId = 2,
                    RoomTypeId = 1
                },
                new RoomServiceType
                {
                    Id=8,
                    RoomServiceId = 2,
                    RoomTypeId = 2
                },new RoomServiceType
                {
                    Id=9,
                    RoomServiceId = 2,
                    RoomTypeId = 3
                },new RoomServiceType
                {
                    Id=10,
                    RoomServiceId = 2,
                    RoomTypeId = 4
                },
                
                new RoomServiceType
                {
                    Id=12,
                    RoomServiceId = 3,
                    RoomTypeId = 1
                },
                new RoomServiceType
                {
                    Id=13,
                    RoomServiceId = 3,
                    RoomTypeId = 2
                },new RoomServiceType
                {
                    Id=14,
                    RoomServiceId = 3,
                    RoomTypeId = 3
                },new RoomServiceType
                {
                    Id=15,
                    RoomServiceId = 3,
                    RoomTypeId = 4
                },new RoomServiceType
                {
                    Id=17,
                    RoomServiceId = 3,
                    RoomTypeId = 4
                },new RoomServiceType
                {
                    Id=18,
                    RoomServiceId = 4,
                    RoomTypeId = 1
                },
                new RoomServiceType
                {
                    Id=11,
                    RoomServiceId = 4,
                    RoomTypeId = 2
                },new RoomServiceType
                {
                    Id=16,
                    RoomServiceId = 4,
                    RoomTypeId = 3
                }
            
            );
        }
    }
}