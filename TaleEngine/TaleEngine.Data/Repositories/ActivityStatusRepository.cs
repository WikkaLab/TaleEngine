using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Repositories
{
    public class ActivityStatusRepository : IActivityStatusRepository
    {
        private readonly TaleEngineContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public ActivityStatusRepository(TaleEngineContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public List<ActivityStatus> GetAll()
        {
            return _dbContext.ActivityStatuses.ToList();
        }

        public ActivityStatus GetById(int entityId)
        {
            return _dbContext.ActivityStatuses
                .FirstOrDefault(aS => aS.Id == entityId);
        }

        public void Insert(ActivityStatus entity)
        {
            _dbContext.ActivityStatuses.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ActivityStatus entity)
        {
            _dbContext.ActivityStatuses.Update(entity);
        }
    }
}