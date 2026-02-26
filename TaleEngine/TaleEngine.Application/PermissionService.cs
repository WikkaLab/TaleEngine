using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public PermissionEntity GetPermission(int id)
        {
            var permission = _unitOfWork.PermissionRepository.GetById(id);
            return permission;
        }

        public List<PermissionEntity> GetAllPermissions()
        {
            var permissions = _unitOfWork.PermissionRepository.GetAll();
            return permissions;
        }

        public void CreatePermission(PermissionEntity permission)
        {
            _unitOfWork.PermissionRepository.Insert(permission);
            _unitOfWork.PermissionRepository.Save();
        }

        public void UpdatePermission(PermissionEntity permission)
        {
            _unitOfWork.PermissionRepository.Update(permission);
            _unitOfWork.PermissionRepository.Save();
        }

        public void DeletePermission(int id)
        {
            _unitOfWork.PermissionRepository.Delete(id);
            _unitOfWork.PermissionRepository.Save();
        }
    }
}
