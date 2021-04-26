using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TaleEngineContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public EventRepository(TaleEngineContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public List<Event> GetAll()
        {
            return _dbContext.Events.ToList();
        }

        public Event GetById(int entityId)
        {
            return _dbContext.Events
                .FirstOrDefault(ev => ev.Id == entityId);
        }

        public void Insert(Event entity)
        {
            _dbContext.Events.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Event entity)
        {
            _dbContext.Events.Update(entity);
        }
    }
}