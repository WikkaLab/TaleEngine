using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialUserStatusData
    {
        public static List<UserStatusEntity> GetUserStatuses()
        {
            return new List<UserStatusEntity>
            {
                new UserStatusEntity { Id = 1, Name = "Pending", Abbr = "PEN", Description = "Pending to confirm" },
                new UserStatusEntity { Id = 2, Name = "Active", Abbr = "ACT", Description = "Active user" },
                new UserStatusEntity { Id = 3, Name = "Revision", Abbr = "REV", Description = "In revision process" },
                new UserStatusEntity { Id = 4, Name = "Banned", Abbr = "BAN", Description = "Banned from event" },
                new UserStatusEntity { Id = 5, Name = "Inactive", Abbr = "INC", Description = "Pending to confirm" },
            };
        }
    }
}
