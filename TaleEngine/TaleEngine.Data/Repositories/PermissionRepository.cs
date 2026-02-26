using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IDatabaseContext _context;

        public PermissionRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);

            _context.Permissions.Remove(entity);
        }

        public List<PermissionEntity> GetAll()
        {
            return _context.Permissions.ToList();
        }

        public PermissionEntity GetById(int entityId)
        {
            return _context.Permissions
                .FirstOrDefault(p => p.Id == entityId);
        }

        public void Insert(PermissionEntity entity)
        {
            _context.Permissions.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(PermissionEntity entity)
        {
            _context.Permissions.Update(entity);
        }
    }
}
