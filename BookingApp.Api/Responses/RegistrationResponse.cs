using BookingApp.Data.Entities;

namespace BookingApp.Api.Responses
{
    public class RegistrationResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
        public RegistrationResponse(User user, string token)
        {
            this.User = user;
            this.Token = token;
        }
    }
}