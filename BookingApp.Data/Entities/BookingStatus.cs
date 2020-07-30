using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class BookingStatus : BaseEntity
    {   
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public bool ValidBooking{get;set;}

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Booking> Bookings{get;set;}
    }
}