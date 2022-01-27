using System.Collections.Generic;
using System.Linq;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public class UserMapper
    {
        public static UserDto Map(UserModel userModel)
        {
            if (userModel == null) return null;

            return new UserDto
            {
                Username = userModel.Username,
                Name = userModel.Name,
                Blog = userModel.Blog,
                Mail = userModel.Mail,
                Website = userModel.Website
            };
        }

        public static UserModel Map(UserDto dto)
        {
            if (dto == null) return null;

            return new UserModel
            {
                Username = dto.Username,
                Name = dto.Name,
                Blog = dto.Blog,
                Mail = dto.Mail,
                Website = dto.Website
            };
        }

        public static List<UserDto> MapToUserDtos(List<UserModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<UserModel> MapToUserModels(List<UserDto> dtos)
        {
            if (dtos == null || dtos.Count == 0) return null;

            return dtos.Select(Map).ToList();
        }
    }
}
