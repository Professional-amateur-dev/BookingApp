using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class BookingStatusDetail : BaseEntity
    {
        public string Status { get; set; }
        public bool ValidBooking{get;set;}
        public string Description { get; set; }
    }
}