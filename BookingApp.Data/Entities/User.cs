using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookingApp.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        ICollection<Guest> Guests{get;set;}

        public User(){}

        public User(string email, string hash)
        {
            this.Email = email;
            this.Password = hash;
        }
    }
}