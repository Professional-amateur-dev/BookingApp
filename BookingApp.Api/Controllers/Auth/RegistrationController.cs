using AutoMapper;
using BookingApp.Api.Requests;
using BookingApp.Api.Responses;
using BookingApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Core.Services;

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
            var user = this.mapper.Map<AppUser>(request);
            user = this.authService.Register(user);

            var response = new RegistrationResponse();
            response.User = user;
            response.Token = "";
            return response;
        }
    }
}