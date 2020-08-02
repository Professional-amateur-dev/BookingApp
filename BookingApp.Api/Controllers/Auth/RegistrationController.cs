using AutoMapper;
using BookingApp.Api.Requests;
using BookingApp.Api.Responses;
using BookingApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Api.Helpers;
using BookingApp.Api.Services;

namespace BookingApp.Api.Controllers.Auth
{
   [Route("api/auth/register")]
    public class RegistrationController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public RegistrationController(
            IAuthService authService,
            IMapper mapper
        ) {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<RegistrationResponse> Register(RegistrationRequest request)
        {
            var appUser = this.mapper.Map<User>(request);

            /* register user: create the entity in database, hash the password, etc. */
            var userDetail = this.authService.Register(appUser);
            var token = JwtHelper.CreateFromUser(appUser);
            var response = new RegistrationResponse(userDetail, token);
            return response;
        }
    }
}