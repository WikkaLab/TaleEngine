using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class PermissionValueQueries : IPermissionValueQueries
    {
        private readonly IPermissionValueService _service;

        public PermissionValueQueries(IPermissionValueService permissionValueService)
        {
            _service = permissionValueService ?? throw new ArgumentNullException(nameof(permissionValueService));
        }

        public PermissionValueDto GetPermissionValueQuery(int permissionValueId)
        {
            var permissionValue = _service.GetPermissionValue(permissionValueId);

            var dto = PermissionValueMapper.Map(permissionValue);
            return dto;
        }

        public List<PermissionValueDto> AllPermissionValuesQuery()
        {
            var permissionValues = _service.GetAllPermissionValues();

            if (permissionValues == null || permissionValues.Count == 0)
            {
                return null;
            }

            var dtos = PermissionValueMapper.Map(permissionValues);
            return dtos;
        }
    }
}
