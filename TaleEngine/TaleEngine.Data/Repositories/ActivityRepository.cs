using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDatabaseContext _context;

        public ActivityRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetAll()
        {
            return _context.Activities.ToList();
        }

        public Activity GetById(int entityId)
        {
            return _context.Activities
                .FirstOrDefault(a => a.Id == entityId);
        }

        public void Insert(Activity entity)
        {
            _context.Activities.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Activity entity)
        {
            _context.Activities.Update(entity);
        }
        
        public List<Activity> GetEventActivities(int editionId)
        {
            return _context.Activities
                .Where(a => a.EditionId == editionId)
                .ToList();
        }
    }
}
