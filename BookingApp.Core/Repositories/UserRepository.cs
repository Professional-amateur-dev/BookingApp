using System.Collections.Generic;
using System.Linq;
using BookingApp.Core.Helpers;
using BookingApp.Data.Database;
using BookingApp.Data.Entities;

namespace BookingApp.Core.Repositories
{
    public interface IUserRepository : IRepository<User> {
        User FindByEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AplicationContext context;
        public UserRepository(AplicationContext context) => this.context = context;

        public User Create(User entity)
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

        public IEnumerable<User> GetAll(string search)
        {
            throw new System.NotImplementedException();
        }

        public User GetOne(long id)
        {
            return this.context.Users
                .Where(u => u.Id == id)
                .First<User>();
        }

        public User Update(long id, User entity)
        {
            throw new System.NotImplementedException();
        }

        public User FindByEmail(string email)
        {
            return this.context.Users
                .Where(u => u.Email.Equals(email))
                .First<User>();
        }
    }
}
