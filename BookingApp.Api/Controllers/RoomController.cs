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

namespace BookingApp.Api.Controllers
{
    [Route("api/rooms")]
    public class RoomController : BaseController
    {

        private readonly IRoomRepository RoomRepository;
        private readonly IMapper mapper;

        public RoomController(
            IRoomRepository RoomRepository,
            IMapper mapper
        )
        {
            this.RoomRepository = RoomRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDetail>> GetAll([FromQuery] string search)
        {
            var Rooms = this.RoomRepository.GetAll(search);
            var Rooms2 = this.mapper.Map<IEnumerable<RoomDetail>>(Rooms);
            return Ok(Rooms2);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomDetail> GetOne(long id)
        {
            var entity = this.RoomRepository.GetOne(id);
            var Room = this.mapper.Map<RoomDetail>(entity);
            return Ok(Room);
        }

        [HttpPatch("{id}")]
        public ActionResult<Room> Patch(int id, [FromBody]JsonPatchDocument<Room> doc)
        {
            var Room = this.RoomRepository.GetOne(id);
            this.RoomRepository.Patch(id, doc);
            return Ok(Room);
        }

        [HttpPost]
        public ActionResult<RoomDetail> CreateRoom(RoomCreate p)
        {
            var Room = this.mapper.Map<Room>(p);
            Room = this.RoomRepository.Create(Room);
            return this.mapper.Map<RoomDetail>(Room);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomDetail> Put(long id, Room p)
        {
            var Room = this.RoomRepository.Update(id, p);
            return Ok(this.mapper.Map<RoomDetail>(Room));
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomDetail> Delete(long id)
        {
            this.RoomRepository.Delete(id);
            return Ok();
        }


    }
}
