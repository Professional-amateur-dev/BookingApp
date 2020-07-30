using System;
using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Api.Profiles
{
    public class BookingStatusProfile : Profile
    {
        public BookingStatusProfile()
        {
            CreateMap<BookingStatus, BookingStatusDetail>();
            CreateMap<BookingStatusCreate, BookingStatus>();
        }
    }
}