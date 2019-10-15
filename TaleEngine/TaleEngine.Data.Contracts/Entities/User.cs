using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }

        //public List<User> Friends { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int StatusId { get; set; }
        public UserStatus Status { get; set; }


        public List<UserToActivityPlay> ActivitiesPlay { get; set; }
        public List<UserToActivityFav> ActivitiesFav { get; set; }
        public List<UserToActivityCreate> ActivitiesCreate { get; set; }

        public List<UserToActivityOperation> ActivitiesOperations { get; set; }

    }
}
