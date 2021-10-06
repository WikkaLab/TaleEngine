using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }

        public List<Role> Roles { get; set; }

        public int StatusId { get; set; }
        public UserStatus Status { get; set; }

        public List<Activity> ActivitiesPlay { get; set; }
        public List<Activity> ActivitiesFav { get; set; }
        public List<Activity> ActivitiesCreate { get; set; }
    }
}
