using AutoMapper;
using BookingApp.Api.Requests;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationRequest, User>().ReverseMap();
            CreateMap<UserDetail, User>().ReverseMap();
        }
    }
}