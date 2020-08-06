using System;
using System.Collections.Generic;
using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Data.Profiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<Guest, GuestDetail>().ReverseMap();
            CreateMap<GuestCreate, Guest>().ReverseMap();
        }
    }
}