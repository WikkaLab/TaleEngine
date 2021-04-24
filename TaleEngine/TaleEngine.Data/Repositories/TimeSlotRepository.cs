using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly TaleEngineContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public TimeSlotRepository(TaleEngineContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<TimeSlot> GetAll()
        {
            return _dbContext.TimeSlot.ToList();
        }

        public TimeSlot GetById(int entityId)
        {
            return _dbContext.TimeSlot
                .FirstOrDefault(a => a.Id == entityId);
        }

        public void Insert(TimeSlot entity)
        {
            _dbContext.TimeSlot.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TimeSlot entity)
        {
            _dbContext.TimeSlot.Update(entity);
        }
    }
}