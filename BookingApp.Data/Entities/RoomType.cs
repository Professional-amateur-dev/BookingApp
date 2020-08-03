using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class RoomType : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int BedCount { get; set; }
        [Required]
        public int PersonCount { get; set; }
        [Required]
        public int Surface { get; set; }

        public RoomService RoomService { get; set; }
        public long RoomServiceId { get; set; }
        public ICollection<Room> Rooms{get;set;}
    
    }
}