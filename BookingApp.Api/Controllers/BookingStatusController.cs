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
    [Route("api/bookingstatuses")]
    public class BookingStatusController : BaseController
    {

        private readonly IBookingStatusRepository BookingStatusRepository;
        private readonly IMapper mapper;

        public BookingStatusController(
            IBookingStatusRepository BookingStatusRepository,
            IMapper mapper
        )
        {
            this.BookingStatusRepository = BookingStatusRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingStatusDetail>> GetAll([FromQuery] string search)
        {
            var BookingStatuses = this.BookingStatusRepository.GetAll(search);
            BookingStatuses = this.mapper.Map<IEnumerable<BookingStatusDetail>>(BookingStatuses);
            return Ok(BookingStatuses);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingStatusDetail> GetOne(long id)
        {
            var entity = this.BookingStatusRepository.GetOne(id);
            var BookingStatus = this.mapper.Map<BookingStatusDetail>(entity);
            return Ok(BookingStatus);
        }

        [HttpPatch("{id}")]
        public ActionResult<BookingStatus> Patch(int id, [FromBody]JsonPatchDocument<BookingStatus> doc)
        {
            var BookingStatus = this.BookingStatusRepository.GetOne(id);
            this.BookingStatusRepository.Patch(id, doc);
            return Ok(BookingStatus);
        }

        [HttpPost]
        public ActionResult<BookingStatusDetail> CreateBookingStatus(BookingStatusCreate p)
        {
            var BookingStatus = this.mapper.Map<BookingStatus>(p);
            BookingStatus = this.BookingStatusRepository.Create(BookingStatus);
            return this.mapper.Map<BookingStatusDetail>(BookingStatus);
        }

        [HttpPut("{id}")]
        public ActionResult<BookingStatusDetail> Put(long id, BookingStatus p)
        {
            var BookingStatus = this.BookingStatusRepository.Update(id, p);
            return Ok(this.mapper.Map<BookingStatusDetail>(BookingStatus));
        }

        [HttpDelete("{id}")]
        public ActionResult<BookingStatusDetail> Delete(long id)
        {
            this.BookingStatusRepository.Delete(id);
            return Ok();
        }


    }
}
