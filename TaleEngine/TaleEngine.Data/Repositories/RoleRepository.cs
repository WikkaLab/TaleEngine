using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private IDatabaseContext _context;

        public RoleRepository(IDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);

            _context.Roles.Remove(entity);
        }

        public List<RoleEntity> GetAll()
        {
            return _context.Roles.ToList();
        }

        public RoleEntity GetById(int entityId)
        {
            return _context.Roles
                .FirstOrDefault(x => x.Id == entityId);
        }

        public void Insert(RoleEntity entity)
        {
            _context.Roles.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RoleEntity entity)
        {
            _context.Roles.Update(entity);
        }
    }
}