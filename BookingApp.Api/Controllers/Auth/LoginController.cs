using BookingApp.Api.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Api.Requests;
using BookingApp.Api.Responses;
using BookingApp.Api.Services;
using BookingApp.Data.Entities;

namespace BookingApp.Api.Controllers.Auth
{
    [Route("api/auth/login")]
    public class LoginController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public LoginController(
            IAuthService authService,
            IMapper mapper
        ) {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {

            var token = this.authService.Login(request.Email, request.Password);
            return new LoginResponse(null, token);
        }
    }
}