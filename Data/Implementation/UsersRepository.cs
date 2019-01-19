using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private BooksEntities context;

        public void AddUser(Users user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            Users user = context.Users.Find(userId);
            context.Users.Remove(user);
        }

        public Users GetUserByID(int userId)
        {
            return context.Users.Find(userId);
        }

        public IEnumerable<Users> GetUsers()
        {
            return context.Users.ToList();
        }

        public void UpdateUser(Users user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

