using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class UserStatusRepository : IUserStatusRepository
    {
        private IDatabaseContext _context;

        public UserStatusRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<UserStatus> GetAll()
        {
            return _context.UserStatuses.ToList();
        }

        public UserStatus GetById(int entityId)
        {
            return _context.UserStatuses
                .FirstOrDefault(a => a.Id == entityId);
        }

        public void Insert(UserStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
