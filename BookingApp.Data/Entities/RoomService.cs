using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Data.Entities
{
    public class RoomService : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public ICollection<RoomType> RoomTypes {get;set;} 
    }
}
