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

        public List<UserEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        public UserEntity GetById(int entityId)
        {
            return _context.Users
                .FirstOrDefault(a => a.Id == entityId);
        }

        public void Insert(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(UserEntity entity)
        {
            _context.Users.Update(entity);
        }
    }
}
