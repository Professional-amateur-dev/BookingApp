using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class Booking : BaseEntity
    {
        public Guest Guest { get; set; }
        public long GuestId { get; set; }

        public BookingStatus BookingStatus { get; set; }
        public long BookingStatusId { get; set; }

        public Room Room { get; set; }
        public long RoomId { get; set; }

        public ICollection<Bill> Bills { get; set; }

        [Required]
        public DateTime BeginningDate { get; set; }
       
        [Required]
        public DateTime EndingDate { get; set; }
    }
}