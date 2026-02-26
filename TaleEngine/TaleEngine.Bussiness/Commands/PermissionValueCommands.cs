using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Commands
{
    public class PermissionValueCommands : IPermissionValueCommands
    {
        private readonly IPermissionValueService _service;

        public PermissionValueCommands(IPermissionValueService permissionValueService)
        {
            _service = permissionValueService ?? throw new ArgumentNullException(nameof(permissionValueService));
        }

        public void CreateCommand(PermissionValueDto permissionValueDto)
        {
            var entity = PermissionValueMapper.MapToEntity(permissionValueDto);
            _service.CreatePermissionValue(entity);
        }

        public void UpdateCommand(PermissionValueDto permissionValueDto)
        {
            var entity = PermissionValueMapper.MapToEntity(permissionValueDto);
            _service.UpdatePermissionValue(entity);
        }

        public void DeleteCommand(int permissionValueId)
        {
            _service.DeletePermissionValue(permissionValueId);
        }
    }
}
