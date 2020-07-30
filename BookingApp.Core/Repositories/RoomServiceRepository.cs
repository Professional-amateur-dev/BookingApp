using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{

    public interface IRoomServiceRepository : IRepository<RoomService>
    {
        RoomService Patch(long id, JsonPatchDocument<RoomService> doc);
    }
    public class RoomServiceRepository : IRoomServiceRepository
    {
        private readonly BookingAppContext context;

        public RoomServiceRepository(BookingAppContext context) => this.context = context;

        
        public RoomService GetOne(long id)
        {
            return this.context.RoomServices
                .Where(p => p.Id == id)
                .First<RoomService>();
        }

        public IEnumerable<RoomService> GetAll(string search)
        {
            var query = this.context.RoomServices.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.Name.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.RoomServices.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public RoomService Create(RoomService entity)
        {
            this.context.RoomServices.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public RoomService Update(long id, RoomService doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public RoomService Patch(long id, JsonPatchDocument<RoomService> doc)
        {
            var RoomService = this.GetOne(id);
            doc.ApplyTo(RoomService);
            this.context.SaveChanges();
            return RoomService;
        }

    }
}
