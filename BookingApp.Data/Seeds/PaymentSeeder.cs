using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class PaymentSeeder
    {
        public static void SeedPayment(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Status = true,
                    Type = "Visa",
                    Description = "opis placanja visom"
                },
                new Payment
                {
                    Id = 2,
                    Status = false,
                    Type = "Mastercard",
                    Description = "placanje nije proslo itd itd"
                },
                new Payment
                {
                    Id = 3,
                    Status = true,
                    Type = "Visa",
                    Description = "opis placanja visom br 3"
                }
            );
        }
    }
}