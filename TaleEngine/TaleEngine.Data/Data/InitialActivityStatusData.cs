using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialActivityStatusData
    {
        public static List<ActivityStatusEntity> GetActivityStatuses()
        {
            return new List<ActivityStatusEntity>()
            {
                new ActivityStatusEntity
                {
                    Id = 1,
                    Name = "Pending",
                    Abbr = "PEN",
                    Description = "Waiting for approval"
                },
                new ActivityStatusEntity
                {
                    Id = 2,
                    Name = "Active",
                    Abbr = "ACT",
                    Description = "Accepted and waiting for participants"
                },
                new ActivityStatusEntity
                {
                    Id = 3,
                    Name = "Revision",
                    Abbr = "REV",
                    Description = "In revision process"
                },
                new ActivityStatusEntity
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
