using System.Collections.Generic;
using System.Linq;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public class UserMapper
    {
        public static UserEntity Map(UserModel userModel)
        {
            if (userModel == null) return null;

            return new UserEntity
            {
                Username = userModel.Username,
                Name = userModel.Name,
                Blog = userModel.Blog,
                Mail = userModel.Mail,
                Website = userModel.Website,
                StatusId = userModel.Status
            };
        }

        public static UserModel Map(UserEntity userEntity)
        {
            if (userEntity == null) return null;

            return new UserModel
            {
                Username = userEntity.Username,
                Name = userEntity.Name,
                Website = userEntity.Website,
                Mail = userEntity.Mail,
                Blog = userEntity.Blog,
                Status = userEntity.StatusId
            };
        }

        public static List<UserEntity> MapToUsers(List<UserModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<UserModel> MapToUserModels(List<UserEntity> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
