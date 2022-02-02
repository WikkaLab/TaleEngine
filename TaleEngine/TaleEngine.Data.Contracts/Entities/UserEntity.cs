using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }

        public List<RoleEntity> Roles { get; set; }

        public int StatusId { get; set; }
        public UserStatusEntity Status { get; set; }

        public List<ActivityEntity> ActivitiesPlay { get; set; }
        public List<ActivityEntity> ActivitiesFav { get; set; }
        public List<ActivityEntity> ActivitiesCreate { get; set; }
    }
}
