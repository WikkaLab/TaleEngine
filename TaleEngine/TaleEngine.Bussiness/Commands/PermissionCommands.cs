using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Commands
{
    public class PermissionCommands : IPermissionCommands
    {
        private readonly IPermissionService _service;

        public PermissionCommands(IPermissionService permissionService)
        {
            _service = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
        }

        public void CreateCommand(PermissionDto permissionDto)
        {
            var entity = PermissionMapper.MapToEntity(permissionDto);
            _service.CreatePermission(entity);
        }

        public void UpdateCommand(PermissionDto permissionDto)
        {
            var entity = PermissionMapper.MapToEntity(permissionDto);
            _service.UpdatePermission(entity);
        }

        public void DeleteCommand(int permissionId)
        {
            _service.DeletePermission(permissionId);
        }
    }
}
