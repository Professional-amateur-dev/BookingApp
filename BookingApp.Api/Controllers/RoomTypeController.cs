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
    [Route("api/roomtypes")]
    public class RoomTypeController : BaseController
    {

        private readonly IRoomTypeRepository RoomTypeRepository;
        private readonly IMapper mapper;

        public RoomTypeController(
            IRoomTypeRepository RoomTypeRepository,
            IMapper mapper
        )
        {
            this.RoomTypeRepository = RoomTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomTypeDetail>> GetAll([FromQuery] string search)
        {
            var RoomTypes = this.RoomTypeRepository.GetAll(search);
            var RoomTypes2 = this.mapper.Map<IEnumerable<RoomTypeDetail>>(RoomTypes);
            return Ok(RoomTypes2);
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
