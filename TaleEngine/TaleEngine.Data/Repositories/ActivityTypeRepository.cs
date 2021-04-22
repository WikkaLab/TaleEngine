using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly DatabaseContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ActivityTypeRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public List<ActivityType> GetAll()
        {
            return _context.ActivityTypes.ToList();
        }

        public ActivityType GetById(int entityId)
        {
            return _context.ActivityTypes
                .FirstOrDefault(aT => aT.Id == entityId);
        }

        public void Insert(ActivityType entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ActivityType entity)
        {
            throw new System.NotImplementedException();
        }
    }
}