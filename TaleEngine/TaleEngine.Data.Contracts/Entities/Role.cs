using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }


        public List<User> Users { get; set; }

        public List<RoleToPermission> Permissions { get; set; }
    }
}
