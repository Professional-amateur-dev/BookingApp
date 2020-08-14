using System;
using AutoMapper;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;

namespace BookingApp.Data.Profiles {
    public class RoomTypeProfile : Profile {
        public RoomTypeProfile () {
            CreateMap<RoomType, RoomTypeDetail> ();            
            CreateMap<RoomTypeCreate, RoomType> ();

            /*CreateMap<RoomTypeDetail, RoomType> ()
                .ForMember (entity => entity.RoomServiceTypes, opt => opt.MapFrom (model => model.RoomServices))
                .AfterMap ((model, entity) => {
                    foreach (var entityUserAndTag in entity.RoomServiceTypes) {
                        entityUserAndTag.RoomService= entity.RoomService;
                    }
                }).ReverseMap();

               /*CreateMap<RoomServiceDetail, RoomService>()
                .ForMember(entity => entity.RoomServiceTypes, opt => opt.MapFrom(model => model)).ReverseMap();
                */

        }
    }
}