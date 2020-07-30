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
    [Route("api/guests")]
    public class GuestController : BaseController
    {

        private readonly IGuestRepository GuestRepository;
        private readonly IMapper mapper;

        public GuestController(
            IGuestRepository GuestRepository,
            IMapper mapper
        )
        {
            this.GuestRepository = GuestRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GuestDetail>> GetAll([FromQuery] string search)
        {
            var Guests = this.GuestRepository.GetAll(search);
            Guests = this.mapper.Map<IEnumerable<GuestDetail>>(Guests);
            return Ok(Guests);
        }

        [HttpGet("{id}")]
        public ActionResult<GuestDetail> GetOne(long id)
        {
            var entity = this.GuestRepository.GetOne(id);
            var Guest = this.mapper.Map<GuestDetail>(entity);
            return Ok(Guest);
        }

        [HttpPatch("{id}")]
        public ActionResult<Guest> Patch(int id, [FromBody]JsonPatchDocument<Guest> doc)
        {
            var Guest = this.GuestRepository.GetOne(id);
            this.GuestRepository.Patch(id, doc);
            return Ok(Guest);
        }

        [HttpPost]
        public ActionResult<GuestDetail> CreateGuest(GuestCreate p)
        {
            var Guest = this.mapper.Map<Guest>(p);
            Guest = this.GuestRepository.Create(Guest);
            return this.mapper.Map<GuestDetail>(Guest);
        }

        [HttpPut("{id}")]
        public ActionResult<GuestDetail> Put(long id, Guest p)
        {
            var Guest = this.GuestRepository.Update(id, p);
            return Ok(this.mapper.Map<GuestDetail>(Guest));
        }

        [HttpDelete("{id}")]
        public ActionResult<GuestDetail> Delete(long id)
        {
            this.GuestRepository.Delete(id);
            return Ok();
        }


    }
}
