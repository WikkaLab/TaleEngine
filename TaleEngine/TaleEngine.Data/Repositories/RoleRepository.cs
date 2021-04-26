using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Contracts.SeedWork;

namespace TaleEngine.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TaleEngineContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public RoleRepository(TaleEngineContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Role entity)
        {
            _dbContext.Roles.Add(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Role entity)
        {
            _dbContext.Roles.Update(entity);
        }
    }
}