using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialActivityStatusData
    {
        public static List<ActivityStatus> GetActivityStatuses()
        {
            return new List<ActivityStatus>()
            {
                new ActivityStatus
                {
                    Id = 1,
                    Name = "Pending",
                    Abbr = "PEN",
                    Description = "Waiting for approval"
                },
                new ActivityStatus
                {
                    Id = 2,
                    Name = "Active",
                    Abbr = "ACT",
                    Description = "Accepted and waiting for participants"
                },
                new ActivityStatus
                {
                    Id = 3,
                    Name = "Revision",
                    Abbr = "REV",
                    Description = "In revision process"
                },
                new ActivityStatus
                {
                    Id = 4,
                    Name = "Banned",
                    Abbr = "BAN",
                    Description = "Excluded as it doesn't align with the core values"
                }
            };
        }
    }
}
