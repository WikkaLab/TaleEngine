using System;
using System.Collections.Generic;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class PermissionValueService : IPermissionValueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionValueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public PermissionValueEntity GetPermissionValue(int id)
        {
            var permissionValue = _unitOfWork.PermissionValueRepository.GetById(id);
            return permissionValue;
        }

        public List<PermissionValueEntity> GetAllPermissionValues()
        {
            var permissionValues = _unitOfWork.PermissionValueRepository.GetAll();
            return permissionValues;
        }

        public void CreatePermissionValue(PermissionValueEntity permissionValue)
        {
            EnsureValidPermissionValue(permissionValue);
            _unitOfWork.PermissionValueRepository.Insert(permissionValue);
            _unitOfWork.PermissionValueRepository.Save();
        }

        public void UpdatePermissionValue(PermissionValueEntity permissionValue)
        {
            EnsureValidPermissionValue(permissionValue);
            _unitOfWork.PermissionValueRepository.Update(permissionValue);
            _unitOfWork.PermissionValueRepository.Save();
        }

        public void DeletePermissionValue(int id)
        {
            _unitOfWork.PermissionValueRepository.Delete(id);
            _unitOfWork.PermissionValueRepository.Save();
        }

        private static void EnsureValidPermissionValue(PermissionValueEntity permissionValue)
        {
            if (permissionValue == null)
            {
                throw new ArgumentNullException(nameof(permissionValue));
            }

            if (permissionValue.Id > 0 && System.Enum.IsDefined(typeof(PermissionValueEnum), permissionValue.Id))
            {
                return;
            }

            var name = permissionValue.Name?.Trim();
            var abbr = permissionValue.Abbr?.Trim();

            if (!string.IsNullOrEmpty(name) && System.Enum.TryParse<PermissionValueEnum>(name, true, out var nameValue))
            {
                permissionValue.Id = (int)nameValue;
                return;
            }

            if (!string.IsNullOrEmpty(abbr) && System.Enum.TryParse<PermissionValueEnum>(abbr, true, out var abbrValue))
            {
                permissionValue.Id = (int)abbrValue;
                return;
            }

            throw new ArgumentOutOfRangeException(nameof(permissionValue), "Permission value is not valid.");
        }
    }
}
