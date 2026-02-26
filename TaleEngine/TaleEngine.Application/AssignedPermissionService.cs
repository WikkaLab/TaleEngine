using System;
using System.Collections.Generic;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class AssignedPermissionService : IAssignedPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignedPermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public AssignedPermissionEntity GetAssignedPermission(int id)
        {
            var assignedPermission = _unitOfWork.AssignedPermissionRepository.GetById(id);
            return assignedPermission;
        }

        public List<AssignedPermissionEntity> GetAllAssignedPermissions()
        {
            var assignedPermissions = _unitOfWork.AssignedPermissionRepository.GetAll();
            return assignedPermissions;
        }

        public List<AssignedPermissionEntity> GetAssignedPermissionsByRole(int roleId)
        {
            var assignedPermissions = _unitOfWork.AssignedPermissionRepository.GetByRoleId(roleId);
            return assignedPermissions;
        }

        public void AssignPermissionToRole(int roleId, int permissionId, int permissionValueId)
        {
            if (!System.Enum.IsDefined(typeof(PermissionValueEnum), permissionValueId))
            {
                throw new ArgumentOutOfRangeException(nameof(permissionValueId), "Permission value is not valid.");
            }

            var assignedPermission = new AssignedPermissionEntity
            {
                RoleId = roleId,
                PermissionId = permissionId,
                PermissionValueId = permissionValueId
            };

            _unitOfWork.AssignedPermissionRepository.Insert(assignedPermission);
            _unitOfWork.AssignedPermissionRepository.Save();
        }

        public void RemovePermissionFromRole(int roleId, int permissionId, int permissionValueId)
        {
            if (!System.Enum.IsDefined(typeof(PermissionValueEnum), permissionValueId))
            {
                throw new ArgumentOutOfRangeException(nameof(permissionValueId), "Permission value is not valid.");
            }

            _unitOfWork.AssignedPermissionRepository.DeleteByRoleIdAndPermissionId(roleId, permissionId, permissionValueId);
            _unitOfWork.AssignedPermissionRepository.Save();
        }
    }
}
