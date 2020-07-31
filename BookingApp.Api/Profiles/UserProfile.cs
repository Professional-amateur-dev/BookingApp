using AutoMapper;
using BookingApp.Api.Requests;
using BookingApp.Data.Entities;

namespace BookingApp.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationRequest, User>().ReverseMap();
        }
    }
}