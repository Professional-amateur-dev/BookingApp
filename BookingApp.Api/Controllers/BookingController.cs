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
    [Route("api/bookings")]
    public class BookingController : BaseController
    {

        private readonly IBookingRepository BookingRepository;
        private readonly IMapper mapper;

        public BookingController(
            IBookingRepository BookingRepository,
            IMapper mapper
        )
        {
            this.BookingRepository = BookingRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<BookingDetail>> GetAll([FromQuery] string search)
        {
            var Bookings = this.BookingRepository.GetAll(search);
            var Bookings2 = this.mapper.Map<IEnumerable<BookingDetail>>(Bookings);
            return Ok(Bookings2);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDetail> GetOne(long id)
        {
            var entity = this.BookingRepository.GetOne(id);
            var Booking = this.mapper.Map<BookingDetail>(entity);
            return Ok(Booking);
        }

        [HttpPatch("{id}")]
        public ActionResult<Booking> Patch(int id, [FromBody]JsonPatchDocument<Booking> doc)
        {
            var Booking = this.BookingRepository.GetOne(id);
            this.BookingRepository.Patch(id, doc);
            return Ok(Booking);
        }

        [HttpPost]
        public ActionResult<BookingDetail> CreateBooking(BookingCreate p)
        {
            var Booking = this.mapper.Map<Booking>(p);
            Booking = this.BookingRepository.Create(Booking);
            return this.mapper.Map<BookingDetail>(Booking);
        }

        [HttpPut("{id}")]
        public ActionResult<BookingDetail> Put(long id, Booking p)
        {
            var Booking = this.BookingRepository.Update(id, p);
            return Ok(this.mapper.Map<BookingDetail>(Booking));
        }

        [HttpDelete("{id}")]
        public ActionResult<BookingDetail> Delete(long id)
        {
            this.BookingRepository.Delete(id);
            return Ok();
        }


    }
}
