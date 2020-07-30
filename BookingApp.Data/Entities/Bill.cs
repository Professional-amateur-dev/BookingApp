using System;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class Bill : BaseEntity
    {
        public Booking Booking { get; set; }
        public long BookingId { get; set; }

        public Payment Payment { get; set; }
        public long PaymentId { get; set; }

        [Required]
        public double Amount { get; set; }

        //kad je izdan
        [Required]
        public DateTime InvoiceDate { get; set; }

        //kad ga je potrebno platiti
        [Required]
        public DateTime InvoiceDueDate { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        [MaxLength(10)]
        public string InvoiceNum { get; set; }

        //mjesto izdavanja racuna
        [Required]
        public long SalePoint { get; set; }
    }
}