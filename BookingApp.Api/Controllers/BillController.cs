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
    [Route("api/bills")]
    public class BillController : BaseController
    {

        private readonly IBillRepository BillRepository;
        private readonly IMapper mapper;

        public BillController(
            IBillRepository BillRepository,
            IMapper mapper
        )
        {
            this.BillRepository = BillRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BillDetail>> GetAll([FromQuery] string search)
        {
            var Bills = this.BillRepository.GetAll(search);
            Bills = this.mapper.Map<IEnumerable<BillDetail>>(Bills);
            return Ok(Bills);
        }

        [HttpGet("{id}")]
        public ActionResult<BillDetail> GetOne(long id)
        {
            var entity = this.BillRepository.GetOne(id);
            var Bill = this.mapper.Map<BillDetail>(entity);
            return Ok(Bill);
        }

        [HttpPatch("{id}")]
        public ActionResult<Bill> Patch(int id, [FromBody]JsonPatchDocument<Bill> doc)
        {
            var Bill = this.BillRepository.GetOne(id);
            this.BillRepository.Patch(id, doc);
            return Ok(Bill);
        }

        [HttpPost]
        public ActionResult<BillDetail> CreateBill(BillCreate p)
        {
            var Bill = this.mapper.Map<Bill>(p);
            Bill = this.BillRepository.Create(Bill);
            return this.mapper.Map<BillDetail>(Bill);
        }

        [HttpPut("{id}")]
        public ActionResult<BillDetail> Put(long id, Bill p)
        {
            var Bill = this.BillRepository.Update(id, p);
            return Ok(this.mapper.Map<BillDetail>(Bill));
        }

        [HttpDelete("{id}")]
        public ActionResult<BillDetail> Delete(long id)
        {
            this.BillRepository.Delete(id);
            return Ok();
        }


    }
}
