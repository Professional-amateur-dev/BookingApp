using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class RoomServiceType : BaseEntity
    {
        public long RoomServiceId { get; set; }
        public RoomService RoomService { get; set; }
        public long RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
    }
    
}