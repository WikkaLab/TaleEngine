﻿using System;
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
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Role entity)
        {
            _context.Roles.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Role entity)
        {
            _context.Roles.Update(entity);
        }
    }
}