using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Core.Repositories;
using BookingApp.Data.Entities;
using BookingApp.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Api.Responses;
using BookingApp.Api.Requests;
using RoomTypes.Api.Services;

namespace BookingApp.Api.Controllers
{
    [Route("api/roomtypes")]
    public class RoomTypeController : BaseController
    {

        private readonly IRoomTypeRepository RoomTypeRepository;
        
        private readonly IRoomTypeService roomTypeService;
        private readonly IMapper mapper;

        public RoomTypeController(
            IRoomTypeService roomTypeService,
            IRoomTypeRepository RoomTypeRepository,
            IMapper mapper
        )
        {
            this.RoomTypeRepository = RoomTypeRepository;
            this.mapper = mapper;
            this.roomTypeService = roomTypeService;
        }

        [HttpGet]
        public ActionResult<RoomTypePaginatedResponse> GetAll([FromQuery] PaginatedRoomTypeRequest request)
        {
            var rt = this.roomTypeService.GetPaginatedResponse(request);
            return Ok(rt);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomTypeDetail> GetOne(long id)
        {
            var entity = this.RoomTypeRepository.GetOne(id);
            var RoomType = this.mapper.Map<RoomTypeDetail>(entity);
            return Ok(RoomType);
        }

        [HttpPatch("{id}")]
        public ActionResult<RoomType> Patch(int id, [FromBody]JsonPatchDocument<RoomType> doc)
        {
            var RoomType = this.RoomTypeRepository.GetOne(id);
            this.RoomTypeRepository.Patch(id, doc);
            return Ok(RoomType);
        }

        [HttpPost]
        public ActionResult<RoomTypeDetail> CreateRoomType(RoomTypeCreate p)
        {
            var RoomType = this.mapper.Map<RoomType>(p);
            RoomType = this.RoomTypeRepository.Create(RoomType);
            return this.mapper.Map<RoomTypeDetail>(RoomType);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomTypeDetail> Put(long id, RoomType p)
        {
            var RoomType = this.RoomTypeRepository.Update(id, p);
            return Ok(this.mapper.Map<RoomTypeDetail>(RoomType));
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomTypeDetail> Delete(long id)
        {
            this.RoomTypeRepository.Delete(id);
            return Ok();
        }


    }
}
