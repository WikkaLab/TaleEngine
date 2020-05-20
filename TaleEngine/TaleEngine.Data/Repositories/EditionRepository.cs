using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class EditionRepository : IEditionRepository
    {
        private readonly IDatabaseContext _context;

        public EditionRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Edition> GetAll()
        {
            return _context.Editions.ToList();
        }

        public Edition GetById(int entityId)
        {
            return _context.Editions.FirstOrDefault(ed => ed.Id == entityId);
        }

        public Edition GetLastEditionInEvent(int ofEvent)
        {
            return _context.Editions.FirstOrDefault(ed => ed.EventId == ofEvent);
        }

        public void Insert(Edition entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Edition entity)
        {
            throw new NotImplementedException();
        }
    }
}
