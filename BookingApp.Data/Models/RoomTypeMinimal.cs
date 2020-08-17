using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class RoomTypeMinimal : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public int BedCount { get; set; }
        public int PersonCount { get; set; }
        public int Surface { get; set; }
        
    }
}