using System;
using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Data.Profiles
{
    public class RoomServiceProfile : Profile
    {
        public RoomServiceProfile()
        {
            CreateMap<RoomService, RoomServiceDetail>();
            CreateMap<RoomServiceCreate, RoomService>();
        }
    }
}