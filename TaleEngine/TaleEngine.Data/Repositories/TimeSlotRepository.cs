using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly IDatabaseContext _context;

        public TimeSlotRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = _context.TimeSlots
                .FirstOrDefault(a => a.Id == entityId && !a.IsDeleted);
            
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.TimeSlots.Update(entity);
            }
        }

        public List<TimeSlotEntity> GetAll()
        {
            return _context.TimeSlots.Where(a => !a.IsDeleted).ToList();
        }

        public TimeSlotEntity GetById(int entityId)
        {
            return _context.TimeSlots
                .FirstOrDefault(a => a.Id == entityId && !a.IsDeleted);
        }

        public void Insert(TimeSlotEntity entity)
        {
            _context.TimeSlots.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TimeSlotEntity entity)
        {
            _context.TimeSlots.Update(entity);
        }
    }
}
