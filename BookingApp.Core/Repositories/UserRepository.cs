using System.Collections.Generic;
using System.Linq;
using BookingApp.Core.Helpers;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;

namespace BookingApp.Core.Repositories
{
    public interface IUserRepository : IRepository<AppUser> {
        AppUser FindByEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly BookingAppContext context;
        public UserRepository(BookingAppContext context) => this.context = context;

        public AppUser Create(AppUser entity)
        {
            entity.Password = PasswordHelper.Hash(entity.Password);
            this.context.Users.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AppUser> GetAll(string search)
        {
            throw new System.NotImplementedException();
        }

        public AppUser GetOne(long id)
        {
            return this.context.Users
                .Where(u => u.Id == id)
                .First<AppUser>();
        }

        public AppUser Update(long id, AppUser entity)
        {
            throw new System.NotImplementedException();
        }

        public AppUser FindByEmail(string email)
        {
            return this.context.Users
                .Where(u => u.Email.Equals(email))
                .First<AppUser>();
        }
    }
}
