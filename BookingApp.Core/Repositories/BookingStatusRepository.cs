using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{
    public interface IBookingStatusRepository : IRepository<BookingStatus>
    {
        BookingStatus Patch(long id, JsonPatchDocument<BookingStatus> doc);
    }
    public class BookingStatusRepository : IBookingStatusRepository
    {
        private readonly BookingAppContext context;

        public BookingStatusRepository(BookingAppContext context) => this.context = context;

        
        public BookingStatus GetOne(long id)
        {
            return this.context.BookingStatuses
                .Where(p => p.Id == id)
                .First<BookingStatus>();
        }

        public IEnumerable<BookingStatus> GetAll(string search)
        {
            var query = this.context.BookingStatuses.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.Description.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.BookingStatuses.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public BookingStatus Create(BookingStatus entity)
        {
            this.context.BookingStatuses.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public BookingStatus Update(long id, BookingStatus doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public BookingStatus Patch(long id, JsonPatchDocument<BookingStatus> doc)
        {
            var BookingStatus = this.GetOne(id);
            doc.ApplyTo(BookingStatus);
            this.context.SaveChanges();
            return BookingStatus;
        }

    }
}
