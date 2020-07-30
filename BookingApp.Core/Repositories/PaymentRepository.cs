using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{

    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment Patch(long id, JsonPatchDocument<Payment> doc);
    }
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BookingAppContext context;

        public PaymentRepository(BookingAppContext context) => this.context = context;

        
        public Payment GetOne(long id)
        {
            return this.context.Payments
                .Where(p => p.Id == id)
                .First<Payment>();
        }

        public IEnumerable<Payment> GetAll(string search)
        {
            var query = this.context.Payments.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.Type.Contains(search) ||
                        p.Description.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.Payments.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public Payment Create(Payment entity)
        {
            this.context.Payments.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Payment Update(long id, Payment doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public Payment Patch(long id, JsonPatchDocument<Payment> doc)
        {
            var Payment = this.GetOne(id);
            doc.ApplyTo(Payment);
            this.context.SaveChanges();
            return Payment;
        }

    }
}
