using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityStatusRepository : IActivityStatusRepository
    {
        private readonly IDatabaseContext _context;

        public ActivityStatusRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = _context.ActivityStatuses
                .FirstOrDefault(aS => aS.Id == entityId && !aS.IsDeleted);
            
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.ActivityStatuses.Update(entity);
            }
        }

        public List<ActivityStatusEntity> GetAll()
        {
            return _context.ActivityStatuses.Where(aS => !aS.IsDeleted).ToList();
        }

        public ActivityStatusEntity GetById(int entityId)
        {
            return _context.ActivityStatuses
                .FirstOrDefault(aS => aS.Id == entityId && !aS.IsDeleted);
        }

        public void Insert(ActivityStatusEntity entity)
        {
            _context.ActivityStatuses.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ActivityStatusEntity entity)
        {
            _context.ActivityStatuses.Update(entity);
        }
    }
}