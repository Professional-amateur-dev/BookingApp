using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Api.Responses
{
    public class RegistrationResponse
    {
        public string Token { get; set; }
        public UserDetail User { get; set; }
        public RegistrationResponse(UserDetail user, string token)
        {
            this.User = user;
            this.Token = token;
        }
    }
}