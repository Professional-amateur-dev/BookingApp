using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class RoomServiceTypeDTO
    {
        //stavimo isti naziv kao i prije, ne zovemo ga kao dto, onda ga automapper moze prepoznat
        public RoomServiceDetail RoomService { get; set; }
    }
    
}