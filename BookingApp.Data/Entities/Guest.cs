using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class Guest : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sex { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }  

        public ICollection<Booking> Bookings{get;set;}      
    }
}