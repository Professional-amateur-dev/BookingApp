using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{

    public interface IGuestRepository : IRepository<Guest>
    {
        Guest Patch(long id, JsonPatchDocument<Guest> doc);
    }
    public class GuestRepository : IGuestRepository
    {
        private readonly AplicationContext context;

        public GuestRepository(AplicationContext context) => this.context = context;

        
        public Guest GetOne(long id)
        {
            return this.context.Guests
                .Where(p => p.Id == id)
                .First<Guest>();
        }

        public IEnumerable<Guest> GetAll(string search)
        {
            var query = this.context.Guests.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.FirstName.Contains(search) ||
                        p.LastName.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.Guests.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public Guest Create(Guest entity)
        {
            this.context.Guests.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Guest Update(long id, Guest doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public Guest Patch(long id, JsonPatchDocument<Guest> doc)
        {
            var Guest = this.GetOne(id);
            doc.ApplyTo(Guest);
            this.context.SaveChanges();
            return Guest;
        }

    }
}
