using BookingApp.Api.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Api.Requests;
using BookingApp.Api.Responses;
using BookingApp.Core.Services;
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
        public ActionResult<string> Login(LoginRequest request)
        {
            var token = this.authService.Login(request.Email, request.Password);


            // var user = this.mapper.Map<AppUser>(request);
            // user = this.authService.Register(user);

            // var response = new RegistrationResponse();
            // response.User = user;
            // response.Token = "";
            return token;
        }
    }
}