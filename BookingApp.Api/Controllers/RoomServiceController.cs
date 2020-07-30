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
    [Route("api/roomservices")]
    public class RoomServiceController : BaseController
    {

        private readonly IRoomServiceRepository RoomServiceRepository;
        private readonly IMapper mapper;

        public RoomServiceController(
            IRoomServiceRepository RoomServiceRepository,
            IMapper mapper
        )
        {
            this.RoomServiceRepository = RoomServiceRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomServiceDetail>> GetAll([FromQuery] string search)
        {
            var RoomServices = this.RoomServiceRepository.GetAll(search);
            RoomServices = this.mapper.Map<IEnumerable<RoomServiceDetail>>(RoomServices);
            return Ok(RoomServices);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomServiceDetail> GetOne(long id)
        {
            var entity = this.RoomServiceRepository.GetOne(id);
            var RoomService = this.mapper.Map<RoomServiceDetail>(entity);
            return Ok(RoomService);
        }

        [HttpPatch("{id}")]
        public ActionResult<RoomService> Patch(int id, [FromBody]JsonPatchDocument<RoomService> doc)
        {
            var RoomService = this.RoomServiceRepository.GetOne(id);
            this.RoomServiceRepository.Patch(id, doc);
            return Ok(RoomService);
        }

        [HttpPost]
        public ActionResult<RoomServiceDetail> CreateRoomService(RoomServiceCreate p)
        {
            var RoomService = this.mapper.Map<RoomService>(p);
            RoomService = this.RoomServiceRepository.Create(RoomService);
            return this.mapper.Map<RoomServiceDetail>(RoomService);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomServiceDetail> Put(long id, RoomService p)
        {
            var RoomService = this.RoomServiceRepository.Update(id, p);
            return Ok(this.mapper.Map<RoomServiceDetail>(RoomService));
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomServiceDetail> Delete(long id)
        {
            this.RoomServiceRepository.Delete(id);
            return Ok();
        }


    }
}
