using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Data.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
