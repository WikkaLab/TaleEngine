using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class AssignedPermissionRepository : IAssignedPermissionRepository
    {
        private readonly IDatabaseContext _context;

        public AssignedPermissionRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            var entity = _context.AssignedPermissions
                .FirstOrDefault(ap => ap.Id == entityId && !ap.IsDeleted);
            
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.AssignedPermissions.Update(entity);
            }
        }

        public void DeleteByRoleIdAndPermissionId(int roleId, int permissionId, int permissionValueId)
        {
            var entity = _context.AssignedPermissions
                .FirstOrDefault(ap => ap.RoleId == roleId 
                    && ap.PermissionId == permissionId 
                    && ap.PermissionValueId == permissionValueId
                    && !ap.IsDeleted);

            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.AssignedPermissions.Update(entity);
            }
        }

        public List<AssignedPermissionEntity> GetAll()
        {
            return _context.AssignedPermissions
                .Include(ap => ap.Permission)
                .Include(ap => ap.PermissionValue)
                .Include(ap => ap.Role)
                .Where(ap => !ap.IsDeleted)
                .ToList();
        }

        public AssignedPermissionEntity GetById(int entityId)
        {
            return _context.AssignedPermissions
                .Include(ap => ap.Permission)
                .Include(ap => ap.PermissionValue)
                .Include(ap => ap.Role)
                .FirstOrDefault(ap => ap.Id == entityId && !ap.IsDeleted);
        }

        public List<AssignedPermissionEntity> GetByRoleId(int roleId)
        {
            return _context.AssignedPermissions
                .Include(ap => ap.Permission)
                .Include(ap => ap.PermissionValue)
                .Where(ap => ap.RoleId == roleId && !ap.IsDeleted)
                .ToList();
        }

        public void Insert(AssignedPermissionEntity entity)
        {
            _context.AssignedPermissions.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(AssignedPermissionEntity entity)
        {
            _context.AssignedPermissions.Update(entity);
        }
    }
}
