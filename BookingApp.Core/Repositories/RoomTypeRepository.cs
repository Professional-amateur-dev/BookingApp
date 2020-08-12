using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{

    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        RoomType Patch(long id, JsonPatchDocument<RoomType> doc);
    }
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly AplicationContext context;

        public RoomTypeRepository(AplicationContext context) => this.context = context;

        
        public RoomType GetOne(long id)
        {
            return this.context.RoomTypes
                    .Where(p=>p.Id == id)
                    .Include(p => p.RoomServiceTypes.Where(p=>p.RoomTypeId == id))
                    .ThenInclude(st => st.RoomService)
                    .First<RoomType>();
        }

        public IEnumerable<RoomType> GetAll(string search)
        {
            var query = this.context.RoomTypes.AsQueryable();
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
            this.context.RoomTypes.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public RoomType Create(RoomType entity)
        {
            this.context.RoomTypes.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public RoomType Update(long id, RoomType doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public RoomType Patch(long id, JsonPatchDocument<RoomType> doc)
        {
            var RoomType = this.GetOne(id);
            doc.ApplyTo(RoomType);
            this.context.SaveChanges();
            return RoomType;
        }

    }
}
