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
            var entity = _context.Editions
                .FirstOrDefault(ed => ed.Id == entityId && !ed.IsDeleted);
            
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.Editions.Update(entity);
            }
        }

        public List<EditionEntity> GetAll()
        {
            return _context.Editions.Where(ed => !ed.IsDeleted).ToList();
        }

        public EditionEntity GetById(int entityId)
        {
            return _context.Editions
                .FirstOrDefault(ed => ed.Id == entityId && !ed.IsDeleted);
        }

        public List<EditionEntity> GetEditions(int ofEvent)
        {
            return _context.Editions.Where(ed => ed.EventId == ofEvent && !ed.IsDeleted).ToList();
        }

        public EditionEntity GetLastEditionInEvent(int ofEvent)
        {
            return _context.Editions
                .Where(ed => !ed.IsDeleted)
                .OrderBy(x => x.DateInit)
                .LastOrDefault(ed => ed.EventId == ofEvent);
        }

        public void Insert(EditionEntity entity)
        {
            _context.Editions.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(EditionEntity entity)
        {
            _context.Editions.Update(entity);
        }
    }
}