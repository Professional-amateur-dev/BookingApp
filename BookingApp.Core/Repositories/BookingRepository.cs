using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking Patch(long id, JsonPatchDocument<Booking> doc);
    }
    public class BookingRepository : IBookingRepository
    {
        private readonly AplicationContext context;

        public BookingRepository(AplicationContext context) => this.context = context;

        
        public Booking GetOne(long id)
        {
            return this.context.Bookings
                .Where(p => p.Id == id)
                .Include(p => p.Guest)
                .First<Booking>();
        }

        public IEnumerable<Booking> GetAll(string search)
        {
            var query = this.context.Bookings.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.Room.RoomType.Type.Contains(search) ||
                        p.Room.RoomType.Description.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.Bookings.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public Booking Create(Booking entity)
        {
            this.context.Bookings.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Booking Update(long id, Booking doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public Booking Patch(long id, JsonPatchDocument<Booking> doc)
        {
            var Booking = this.GetOne(id);
            doc.ApplyTo(Booking);
            this.context.SaveChanges();
            return Booking;
        }

    }
}
