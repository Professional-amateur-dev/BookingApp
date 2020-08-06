using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class PaymentDetail : BaseEntity
    {
        public bool Status{get;set;}
        public string Type { get; set; }
        public string Description { get; set; }
    }
}