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
    [Route("api/payments")]
    public class PaymentController : BaseController
    {

        private readonly IPaymentRepository PaymentRepository;
        private readonly IMapper mapper;

        public PaymentController(
            IPaymentRepository PaymentRepository,
            IMapper mapper
        )
        {
            this.PaymentRepository = PaymentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentDetail>> GetAll([FromQuery] string search)
        {
            var Payments = this.PaymentRepository.GetAll(search);
            var Payments2 = this.mapper.Map<IEnumerable<PaymentDetail>>(Payments);
            return Ok(Payments2);
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentDetail> GetOne(long id)
        {
            var entity = this.PaymentRepository.GetOne(id);
            var Payment = this.mapper.Map<PaymentDetail>(entity);
            return Ok(Payment);
        }

        [HttpPatch("{id}")]
        public ActionResult<Payment> Patch(int id, [FromBody]JsonPatchDocument<Payment> doc)
        {
            var Payment = this.PaymentRepository.GetOne(id);
            this.PaymentRepository.Patch(id, doc);
            return Ok(Payment);
        }

        [HttpPost]
        public ActionResult<PaymentDetail> CreatePayment(PaymentCreate p)
        {
            var Payment = this.mapper.Map<Payment>(p);
            Payment = this.PaymentRepository.Create(Payment);
            return this.mapper.Map<PaymentDetail>(Payment);
        }

        [HttpPut("{id}")]
        public ActionResult<PaymentDetail> Put(long id, Payment p)
        {
            var Payment = this.PaymentRepository.Update(id, p);
            return Ok(this.mapper.Map<PaymentDetail>(Payment));
        }

        [HttpDelete("{id}")]
        public ActionResult<PaymentDetail> Delete(long id)
        {
            this.PaymentRepository.Delete(id);
            return Ok();
        }


    }
}
