using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDatabaseContext _context;

        public EventRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);

            _context.Events.Remove(entity);
        }

        public List<EventEntity> GetAll()
        {
            return _context.Events.ToList();
        }

        public EventEntity GetById(int entityId)
        {
            return _context.Events
                .FirstOrDefault(ev => ev.Id == entityId);
        }

        public void Insert(EventEntity entity)
        {
            _context.Events.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(EventEntity entity)
        {
            _context.Events.Update(entity);
        }
    }
}