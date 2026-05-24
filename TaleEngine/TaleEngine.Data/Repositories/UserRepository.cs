using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var entity = _context.Users
                .FirstOrDefault(u => u.Id == entityId && !u.IsDeleted);

            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.Users.Update(entity);
            }
        }

        public List<UserEntity> GetAll()
        {
            return _context.Users.Where(u => !u.IsDeleted).ToList();
        }

        public UserEntity GetById(int entityId)
        {
            return _context.Users
                .FirstOrDefault(a => a.Id == entityId && !a.IsDeleted);
        }

        public UserEntity GetByIdWithActivities(int entityId, int editionId = default)
        {
            var query = _context.Users
                .Include(u => u.ActivitiesPlay)
                .Include(u => u.ActivitiesFav)
                .Include(u => u.ActivitiesWaitingList)
                .Where(u => u.Id == entityId && !u.IsDeleted);

            var user = query.FirstOrDefault();

            if (user == null || editionId == default)
            {
                return user;
            }

            user.ActivitiesPlay = (user.ActivitiesPlay ?? new List<ActivityEntity>())
                .Where(a => !a.IsDeleted && a.EditionId == editionId)
                .ToList();

            user.ActivitiesFav = (user.ActivitiesFav ?? new List<ActivityEntity>())
                .Where(a => !a.IsDeleted && a.EditionId == editionId)
                .ToList();

            user.ActivitiesWaitingList = (user.ActivitiesWaitingList ?? new List<ActivityEntity>())
                .Where(a => !a.IsDeleted && a.EditionId == editionId)
                .ToList();

            return user;
        }

        public void Insert(UserEntity entity)
        {
            _context.Users.Add(entity);
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
