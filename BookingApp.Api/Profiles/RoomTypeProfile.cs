using System;
using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Data.Profiles {
    public class RoomTypeProfile : Profile {
        public RoomTypeProfile () {
            CreateMap<RoomType, RoomTypeDetail> ().ForMember (destination => destination.RoomServices,
                opts => opts.MapFrom (source => source.RoomServiceTypes));
            
            CreateMap<RoomTypeCreate, RoomType> ();

            CreateMap<RoomTypeDetail, RoomType> ()
                // (1)
                .ForMember (entity => entity.RoomServiceTypes, opt => opt.MapFrom (model => model.RoomServices))
                // (5)
                .AfterMap ((model, entity) => {
                    foreach (var entityUserAndTag in model.RoomServiceTypes) {
                        entityUserAndTag.RoomService = entity;
                    }
                }).ReverseMap();

                CreateMap<RoomServiceDetail, RoomService>()
                .ForMember(entity => entity.RoomServiceTypes, opt => opt.MapFrom(model => model)).ReverseMap();

        }
    }
}