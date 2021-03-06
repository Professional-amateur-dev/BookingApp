using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Api.Profiles
{
    public class RoomServiceTypeProfile : Profile
    {
        public RoomServiceTypeProfile()
        {
            CreateMap<RoomServiceType, RoomServiceTypeDTO>().ReverseMap();
            CreateMap<RoomServiceType, RoomServiceTypeDetail>().ReverseMap();
            CreateMap<RoomServiceTypeCreate, RoomServiceType>();
        }
    }
}