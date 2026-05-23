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
            var entity = _context.UserStatuses
                .FirstOrDefault(us => us.Id == entityId && !us.IsDeleted);

            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.UserStatuses.Update(entity);
            }
        }

        public List<UserStatusEntity> GetAll()
        {
            return _context.UserStatuses.Where(us => !us.IsDeleted).ToList();
        }

        public UserStatusEntity GetById(int entityId)
        {
            return _context.UserStatuses
                .FirstOrDefault(a => a.Id == entityId && !a.IsDeleted);
        }

        public void Insert(UserStatusEntity entity)
        {
            _context.UserStatuses.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(UserStatusEntity entity)
        {
            _context.UserStatuses.Update(entity);
        }
    }
}
