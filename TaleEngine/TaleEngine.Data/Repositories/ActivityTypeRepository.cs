using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly IDatabaseContext _context;

        public ActivityTypeRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);

            _context.ActivityTypes.Remove(entity);
        }

        public List<ActivityTypeEntity> GetAll()
        {
            return _context.ActivityTypes.ToList();
        }

        public ActivityTypeEntity GetById(int entityId)
        {
            return _context.ActivityTypes
                .FirstOrDefault(aT => aT.Id == entityId);
        }

        public void Insert(ActivityTypeEntity entity)
        {
            _context.ActivityTypes.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ActivityTypeEntity entity)
        {
            _context.ActivityTypes.Update(entity);
        }
    }
}