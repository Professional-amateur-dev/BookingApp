using System;
using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Data.Profiles {
    public class RoomTypeProfile : Profile {
        public RoomTypeProfile () {
            CreateMap<RoomType, RoomTypeDetail> ();            
            CreateMap<RoomTypeCreate, RoomType> ();
        }
    }
}