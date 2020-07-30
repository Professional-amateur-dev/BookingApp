using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using BookingApp.Core.Helpers;
using BookingApp.Core.Repositories;
using BookingApp.Data.Entities;

namespace BookingApp.Core.Services
{
    public interface IAuthService
    {
        AppUser Register(AppUser user);
        string Login(string email, string password);
    }
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper
        ) {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public AppUser Register(AppUser user)
        {
            this.userRepository.Create(user);
            return user;
        }

        public string Login(string email, string password)
        {
            // find user by email
            var user = this.userRepository.FindByEmail(email);

            // check hash
            var isLoginCorrect = PasswordHelper.IsPasswordCorrect(password, user.Password);

            if(isLoginCorrect) {
                // vrati token
                // return "eysdfsygfdsdmfhbefjgydbf";
                return this.GenerateJwtToken(user);
            }

            // vrati gresku
            return null;
        }

        private string GenerateJwtToken(AppUser user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("kuhergkyegrjhgr5i75");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim("email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}