using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room Patch(long id, JsonPatchDocument<Room> doc);
    }

    public class RoomRepository : IRoomRepository
    {
        private readonly AplicationContext context;

        public RoomRepository(AplicationContext context) => this.context = context;

        
        public Room GetOne(long id)
        {
            return this.context.Rooms
                .Where(p => p.Id == id)
                .First<Room>();
        }

        public IEnumerable<Room> GetAll(string search)
        {
            var query = this.context.Rooms.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    p => p.RoomType.Type.Contains(search) ||
                        p.RoomType.Description.Contains(search)
                );
            }
            return query.ToList();
        }

        public bool Delete(long id)
        {
            this.context.Rooms.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public Room Create(Room entity)
        {
            this.context.Rooms.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public Room Update(long id, Room doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public Room Patch(long id, JsonPatchDocument<Room> doc)
        {
            var Room = this.GetOne(id);
            doc.ApplyTo(Room);
            this.context.SaveChanges();
            return Room;
        }

    }
}
