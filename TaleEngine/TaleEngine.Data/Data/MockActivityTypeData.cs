using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class MockActivityTypeData
    {
        public static List<ActivityType> GetActivityTypes()
        {
            return new List<ActivityType>()
            {
                new ActivityType
                {
                    Id = 1,
                    Name = "TTRPG",
                    Description = "Tabletop roleplaying game session"
                },
                new ActivityType
                {
                    Id = 2,
                    Name = "BoardGames",
                    Description = "Board games for everyone!"
                }
            };
        }
    }
}
