using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Data.Seeds
{
    public static class BillSeeder
    {
        public static void SeedBill(this ModelBuilder modelBuilder){
            
            modelBuilder.Entity<Bill>().HasData(
                new Bill
                {
                    Id = 1,
                    Amount = 234,
                    InvoiceDate = new System.DateTime(2005,12,2),
                    InvoiceDueDate = new System.DateTime(2005,12,20),
                    Status = true,
                    SalePoint= 12,
                    InvoiceNum = "1/27/123",
                    BookingId = 1,
                    PaymentId = 1
                },
                new Bill
                {
                    Id = 2,
                    Amount = 987,
                    InvoiceDate = new System.DateTime(2005,12,2),
                    InvoiceDueDate = new System.DateTime(2005,12,20),
                    Status = false,
                    SalePoint= 1,
                    InvoiceNum = "1/27/987",
                    BookingId = 2,
                    PaymentId = 2
                },
                new Bill
                {
                    Id = 3,
                    Amount = 19834,
                    InvoiceDate = new System.DateTime(2005,12,2),
                    InvoiceDueDate = new System.DateTime(2005,12,20),
                    Status = true,
                    SalePoint= 5,
                    InvoiceNum = "2/5/987",
                    BookingId = 1,
                    PaymentId = 2
                }
        
            );
        }
    }
}