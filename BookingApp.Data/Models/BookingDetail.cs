using System;
using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class BookingDetail : BaseEntity
    {
        public Guest Guest { get; set; }
        public long GuestId { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public long BookingStatusId { get; set; }
        public Room Room { get; set; }
        public long RoomId { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndingDate { get; set; }
    }
}