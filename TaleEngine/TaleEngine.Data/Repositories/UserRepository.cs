using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseContext _context;

        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int entityId)
        {
            return _context.Users
                .FirstOrDefault(a => a.Id == entityId);
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}
