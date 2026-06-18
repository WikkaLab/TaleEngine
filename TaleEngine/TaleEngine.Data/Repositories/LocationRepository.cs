using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDatabaseContext _context;

        public LocationRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = _context.Locations
                .FirstOrDefault(l => l.Id == entityId && !l.IsDeleted);

            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.Locations.Update(entity);
            }
        }

        public List<LocationEntity> GetAll()
        {
            return _context.Locations.Where(l => !l.IsDeleted).ToList();
        }

        public LocationEntity GetById(int entityId)
        {
            return _context.Locations
                .FirstOrDefault(l => l.Id == entityId && !l.IsDeleted);
        }

        public List<LocationEntity> GetByEdition(int editionId)
        {
            return _context.Locations
                .Where(l => l.EditionId == editionId && !l.IsDeleted)
                .ToList();
        }

        public void Insert(LocationEntity entity)
        {
            _context.Locations.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(LocationEntity entity)
        {
            _context.Locations.Update(entity);
        }
    }
}
