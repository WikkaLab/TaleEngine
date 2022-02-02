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
            var entity = GetById(entityId);

            _context.TimeSlots.Remove(entity);
        }

        public List<TimeSlotEntity> GetAll()
        {
            return _context.TimeSlots.ToList();
        }

        public TimeSlotEntity GetById(int entityId)
        {
            return _context.TimeSlots
                .FirstOrDefault(a => a.Id == entityId);
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
