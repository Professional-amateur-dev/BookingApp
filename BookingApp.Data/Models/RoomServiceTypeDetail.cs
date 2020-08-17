using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class RoomServiceTypeDetail : BaseEntity
    {
        public long RoomServiceId { get; set; }
        public RoomServiceDetail RoomService { get; set; }
        public long RoomTypeId { get; set; }
        public RoomTypeMinimal RoomType { get; set; }
    }
}