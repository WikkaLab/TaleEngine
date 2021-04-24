using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Repositories
{
    public class EditionRepository : IEditionRepository
    {
        private readonly TaleEngineContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public EditionRepository(TaleEngineContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Edition> GetAll()
        {
            return _dbContext.Editions.ToList();
        }

        public Edition GetById(int entityId)
        {
            return _dbContext.Editions.FirstOrDefault(ed => ed.Id == entityId);
        }

        public Edition GetLastEditionInEvent(int ofEvent)
        {
            return _dbContext.Editions.FirstOrDefault(ed => ed.EventId == ofEvent);
        }

        public void Insert(Edition entity)
        {
            _dbContext.Editions.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Edition entity)
        {
            _dbContext.Editions.Update(entity);
        }
    }
}