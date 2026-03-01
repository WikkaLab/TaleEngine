using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class PermissionValueRepository : IPermissionValueRepository
    {
        private readonly IDatabaseContext _context;

        public PermissionValueRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = _context.PermissionsValue
                .FirstOrDefault(pv => pv.Id == entityId && !pv.IsDeleted);
            
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.PermissionsValue.Update(entity);
            }
        }

        public List<PermissionValueEntity> GetAll()
        {
            return _context.PermissionsValue.Where(pv => !pv.IsDeleted).ToList();
        }

        public PermissionValueEntity GetById(int entityId)
        {
            return _context.PermissionsValue
                .FirstOrDefault(pv => pv.Id == entityId && !pv.IsDeleted);
        }

        public void Insert(PermissionValueEntity entity)
        {
            _context.PermissionsValue.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(PermissionValueEntity entity)
        {
            _context.PermissionsValue.Update(entity);
        }
    }
}
