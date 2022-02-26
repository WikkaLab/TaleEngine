using System.Collections.Generic;
using System.Linq;
using TaleEngine.Aggregates.UserAggregate;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class UserMapper
    {
        public static UserEntity Map(User user)
        {
            if (user == null) return null;

            return new UserEntity
            {
                Username = user.Username,
                Name = user.Name,
                Blog = user.Blog,
                Mail = user.Mail,
                Website = user.Website,
                StatusId = user.Status
            };
        }

        public static UserDto Map(UserEntity userEntity)
        {
            if (userEntity == null) return null;

            return new UserDto
            {
                Username = userEntity.Username,
                Name = userEntity.Name,
                Website = userEntity.Website,
                Mail = userEntity.Mail,
                Blog = userEntity.Blog,
                //Status = userEntity.StatusId
            };
        }

        public static List<UserEntity> MapToUsers(List<User> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<UserDto> MapToUserModels(List<UserEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
