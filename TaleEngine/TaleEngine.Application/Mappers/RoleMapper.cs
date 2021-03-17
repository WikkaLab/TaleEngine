using System.Collections.Generic;
using System.Linq;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public class RoleMapper
    {
        public static RoleDto Map(RoleModel roleModel)
        {
            if (roleModel == null) return null;

            return new RoleDto
            {
                Id = roleModel.Id,
                Name = roleModel.Name,
                Description = roleModel.Description
            };
        }

        public static RoleModel Map(RoleDto dto)
        {
            if (dto == null) return null;

            return new RoleModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static List<RoleDto> MapToRoleDtos(List<RoleModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<RoleModel> MapToRoleModels(List<RoleDto> dtos)
        {
            if (dtos == null || dtos.Count == 0) return null;

            return dtos.Select(Map).ToList();
        }
    }
}
