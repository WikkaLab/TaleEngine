using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class MockActivityStatusData
    {
        public static List<ActivityStatus> GetActivityStatuses()
        {
            return new List<ActivityStatus>()
            {
                new ActivityStatus
                {
                    Id = 1,
                    Name = "Pending",
                    Description = "Waiting for approval"
                },
                new ActivityStatus
                {
                    Id = 2,
                    Name = "Active",
                    Description = "Accepted and waiting for participants"
                }
            };
        }
    }
}
