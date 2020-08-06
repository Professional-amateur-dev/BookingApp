using System;
using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class BillDetail : BaseEntity
    {
         public Booking Booking { get; set; }
        public long BookingId { get; set; }

        public Payment Payment { get; set; }
        public long PaymentId { get; set; }
        public double Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public bool Status { get; set; }
        public string InvoiceNum { get; set; }
        public long SalePoint { get; set; }
    }
}