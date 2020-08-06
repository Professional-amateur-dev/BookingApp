using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class RoomDetail : BaseEntity
    {
        public RoomType RoomType{get;set;}
        public long RoomTypeId { get; set; }
        public double Price { get; set; }
    }
}