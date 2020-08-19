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

        List<RoomType> GetPaginatedRoomTypes(int page = 1, string? search = null, string? sort = null);

        int PerPage { get; set; }

        int Count(string search);
    }
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly AplicationContext context;
        public int PerPage { get; set; } = 2;

        public RoomTypeRepository(AplicationContext context) => this.context = context;

        
        public RoomType GetOne(long id)
        {
            return this.context.RoomTypes
                    .Where(p=>p.Id == id)
                    .Include(p => p.RoomServiceTypes)
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

        public List<RoomType> GetPaginatedRoomTypes(int page, string search, string sort)
        {
            var query = this.context.RoomTypes.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Type.Contains(search) || p.Description.Contains(search));
            }

            if (!string.IsNullOrEmpty(sort))
            {
                string[] elements = sort.Split(":"); // 0 => title, 1 => asc
                /* TODO: implement dynamic sort */
                query = query.OrderByDescending(p => p.Type);
            }

            return query.Skip((page - 1) * this.PerPage)
                .Take(this.PerPage)
                .ToList();
        }

        public int Count(string search)
        {
            var query = this.context.RoomTypes.AsQueryable();
            if(!string.IsNullOrEmpty(search))
            {
                return query.Count(p => p.Type.Contains(search) || p.Description.Contains(search));
            }

            return query.Count();
        }

    }
}
