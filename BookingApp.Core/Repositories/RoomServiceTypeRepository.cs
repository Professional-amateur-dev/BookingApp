using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace BookingApp.Core.Repositories
{

    public interface IRoomServiceTypeRepository : IRepository<RoomServiceType>
    {
        RoomServiceType Patch(long id, JsonPatchDocument<RoomServiceType> doc);
    }
    public class RoomServiceTypeRepository : IRoomServiceTypeRepository
    {
        private readonly AplicationContext context;

        public RoomServiceTypeRepository(AplicationContext context) => this.context = context;

        
        public RoomServiceType GetOne(long id)
        {
            return this.context.RoomServiceTypes
                .Where(p => p.Id == id)
                .First<RoomServiceType>();
        }

        public IEnumerable<RoomServiceType> GetAll(string a)
        {
            return this.context.RoomServiceTypes.ToList();
        }

        public bool Delete(long id)
        {
            this.context.RoomServiceTypes.Remove(this.GetOne(id));
            this.context.SaveChanges();
            return true;
        }

        public RoomServiceType Create(RoomServiceType entity)
        {
            this.context.RoomServiceTypes.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public RoomServiceType Update(long id, RoomServiceType doc)
        {
            doc.Id = id;
            this.context.Entry(doc).State = EntityState.Modified;
            this.context.SaveChanges();
            return this.GetOne(id);
        }

        public RoomServiceType Patch(long id, JsonPatchDocument<RoomServiceType> doc)
        {
            var RoomServiceType = this.GetOne(id);
            doc.ApplyTo(RoomServiceType);
            this.context.SaveChanges();
            return RoomServiceType;
        }

    }
}
