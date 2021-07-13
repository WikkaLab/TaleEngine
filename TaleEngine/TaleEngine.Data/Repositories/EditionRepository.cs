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

        public List<Edition> GetAll()
        {
            return _context.Editions.ToList();
        }

        public Edition GetById(int entityId)
        {
            return _context.Editions.FirstOrDefault(ed => ed.Id == entityId);
        }

        public List<Edition> GetEditions(int ofEvent)
        {
            return _context.Editions.Where(ed => ed.EventId == ofEvent).ToList();
        }

        public Edition GetLastEditionInEvent(int ofEvent)
        {
            return _context.Editions.LastOrDefault(ed => ed.EventId == ofEvent);
        }

        public void Insert(Edition entity)
        {
            _context.Editions.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Edition entity)
        {
            _context.Editions.Update(entity);
        }
    }
}