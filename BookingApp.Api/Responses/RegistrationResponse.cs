using BookingApp.Data.Entities;

namespace BookingApp.Api.Responses
{
    public class RegistrationResponse
    {
        public string Token { get; set; }
        public AppUser User { get; set; }
    }
}