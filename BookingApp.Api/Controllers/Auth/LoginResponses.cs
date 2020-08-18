using BookingApp.Data.Models;
using BookingApp.Data.Entities;

namespace BookingApp.Api.Controllers.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDetail User { get; set; }

        public LoginResponse(UserDetail user, string token)
        {
            this.User = user;
            this.Token = token;
        }
    }
}