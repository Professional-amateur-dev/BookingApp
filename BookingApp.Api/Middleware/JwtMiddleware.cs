using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BookingApp.Api.Helpers;
using BookingApp.Core.Repositories;
using BookingApp.Core.Services;

namespace BookingApp.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(
            HttpContext context,
            IAuthService authService,
            IUserRepository userRepository,
            IConfiguration configuration
        ) {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                await next(context);
            }

            JwtSecurityToken jwtToken;
            try {
                jwtToken = authService.GetValidToken(token);
                var userId = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var user = userRepository.GetOne(userId);
                context.Items["User"] = user;
                await next(context);
            } catch (Exception ex)
            {
                
            }
        }
    }
}