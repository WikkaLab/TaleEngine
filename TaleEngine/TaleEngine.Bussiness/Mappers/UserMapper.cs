using System.Collections.Generic;
using System.Linq;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public class UserMapper
    {
        public static User Map(UserModel userModel)
        {
            if (userModel == null) return null;

            return new User
            {
                Username = userModel.Username,
                Name = userModel.Name,
                Blog = userModel.Blog,
                Mail = userModel.Mail,
                Website = userModel.Website,
                StatusId = userModel.Status
            };
        }

        public static UserModel Map(User userEntity)
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

        public static List<User> MapToUsers(List<UserModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(Map).ToList();
        }

        public static List<UserModel> MapToUserModels(List<User> entities)
        {
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(Map).ToList();
        }
    }
}
