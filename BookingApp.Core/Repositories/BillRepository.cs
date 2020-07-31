using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{

    public interface IBillRepository : IRepository<Bill>
    {
        Bill Patch(long id, JsonPatchDocument<Bill> doc);
    }
    public class BillRepository : IBillRepository
    {
        private readonly AplicationContext context;

        public BillRepository(AplicationContext context) => this.context = context;

        
        public Bill GetOne(long id)
        {
            return this.context.Bills
                .Where(p => p.Id == id)
                .First<Bill>();
        }

        public IEnumerable<Bill> GetAll(string search)
        {
            var query = this.context.Bills.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.InvoiceNum.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.Bills.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public Bill Create(Bill entity)
        {
            this.context.Bills.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Bill Update(long id, Bill doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public Bill Patch(long id, JsonPatchDocument<Bill> doc)
        {
            var Bill = this.GetOne(id);
            doc.ApplyTo(Bill);
            this.context.SaveChanges();
            return Bill;
        }

    }
}
