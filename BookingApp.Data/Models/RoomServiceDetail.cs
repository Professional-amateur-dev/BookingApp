using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class RoomServiceDetail : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
}