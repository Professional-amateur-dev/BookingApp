using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class Room : BaseEntity
    {
        public RoomType RoomType{get;set;}
        public long RoomTypeId { get; set; }

        public ICollection<Booking> Bookings{get;set;}

        [Required]
        public double Price { get; set; }
    }
}