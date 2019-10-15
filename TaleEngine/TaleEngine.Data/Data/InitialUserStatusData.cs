using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialUserStatusData
    {
        public static List<UserStatus> GetUserStatuses()
        {
            return new List<UserStatus>
            {
                new UserStatus { Id = 1, Name = "Pending", Abbr = "PEN", Description = "Pending to confirm" },
                new UserStatus { Id = 2, Name = "Active", Abbr = "ACT", Description = "Active user" },
                new UserStatus { Id = 3, Name = "Revision", Abbr = "REV", Description = "In revision process" },
                new UserStatus { Id = 4, Name = "Banned", Abbr = "BAN", Description = "Banned from event" },
                new UserStatus { Id = 5, Name = "Inactive", Abbr = "INC", Description = "Pending to confirm" },
            };
        }
    }
}
