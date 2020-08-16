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
    [Route("api/roomservicetypes")]
    public class RoomServiceTypeController : BaseController
    {

        private readonly IRoomServiceTypeRepository RoomServiceTypeRepository;
        private readonly IMapper mapper;

        public RoomServiceTypeController(
            IRoomServiceTypeRepository RoomServiceTypeRepository,
            IMapper mapper
        )
        {
            this.RoomServiceTypeRepository = RoomServiceTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomServiceTypeDetail>> GetAll([FromQuery] string search)
        {
            var RoomServiceTypes = this.RoomServiceTypeRepository.GetAll(search);
            var RoomServiceTypes2 = this.mapper.Map<IEnumerable<RoomServiceTypeDetail>>(RoomServiceTypes);
            return Ok(RoomServiceTypes2);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomServiceTypeDetail> GetOne(long id)
        {
            var entity = this.RoomServiceTypeRepository.GetOne(id);
            var RoomServiceType = this.mapper.Map<RoomServiceTypeDetail>(entity);
            return Ok(RoomServiceType);
        }

        [HttpPatch("{id}")]
        public ActionResult<RoomServiceType> Patch(int id, [FromBody]JsonPatchDocument<RoomServiceType> doc)
        {
            var RoomServiceType = this.RoomServiceTypeRepository.GetOne(id);
            this.RoomServiceTypeRepository.Patch(id, doc);
            return Ok(RoomServiceType);
        }

        [HttpPost]
        public ActionResult<RoomServiceTypeDetail> CreateRoomServiceType(RoomServiceTypeCreate p)
        {
            var RoomServiceType = this.mapper.Map<RoomServiceType>(p);
            RoomServiceType = this.RoomServiceTypeRepository.Create(RoomServiceType);
            return this.mapper.Map<RoomServiceTypeDetail>(RoomServiceType);
        }

        [HttpPut("{id}")]
        public ActionResult<RoomServiceTypeDetail> Put(long id, RoomServiceType p)
        {
            var RoomServiceType = this.RoomServiceTypeRepository.Update(id, p);
            return Ok(this.mapper.Map<RoomServiceTypeDetail>(RoomServiceType));
        }

        [HttpDelete("{id}")]
        public ActionResult<RoomServiceTypeDetail> Delete(long id)
        {
            this.RoomServiceTypeRepository.Delete(id);
            return Ok();
        }


    }
}
