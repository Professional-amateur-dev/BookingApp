using BookingApp.Data.Entities;

namespace BookingApp.Data.Models
{
    public class GuestDetail : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }  
        public long UserId {get;set;}
    }
}