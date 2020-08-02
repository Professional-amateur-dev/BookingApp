using System;

namespace BookingApp.Data.Models
{
    public class UserDetail
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set;}
        public string Email { get; set; }
    }
}