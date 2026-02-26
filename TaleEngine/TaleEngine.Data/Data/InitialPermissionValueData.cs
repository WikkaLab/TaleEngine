using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialPermissionValueData
    {
        public static List<PermissionValueEntity> GetPermissionValueData()
        {
            return new List<PermissionValueEntity>
            {
                new PermissionValueEntity { Id = 1, Name = "Allow", Abbr = "ALLOW" },
                new PermissionValueEntity { Id = 2, Name = "Deny", Abbr = "DENY" }
            };
        }
    }
}
