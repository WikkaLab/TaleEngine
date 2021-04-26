using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly TaleEngineContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public ActivityTypeRepository(TaleEngineContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public List<ActivityType> GetAll()
        {
            return _dbContext.ActivityTypes.ToList();
        }

        public ActivityType GetById(int entityId)
        {
            return _dbContext.ActivityTypes
                .FirstOrDefault(aT => aT.Id == entityId);
        }

        public void Insert(ActivityType entity)
        {
            _dbContext.ActivityTypes.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ActivityType entity)
        {
            _dbContext.ActivityTypes.Update(entity);
        }
    }
}