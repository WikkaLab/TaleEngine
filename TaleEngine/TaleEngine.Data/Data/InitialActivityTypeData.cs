using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialActivityTypeData
    {
        public static List<ActivityType> GetActivityTypes()
        {
            return new List<ActivityType>()
            {
                new ActivityType
                {
                    Id = 1,
                    Name = "Tabletop role-playing games",
                    Abbr = "TTRPG",
                    Description = "Tabletop roleplaying game session"
                },
                new ActivityType
                {
                    Id = 2,
                    Name = "Board games",
                    Abbr = "BG",
                    Description = "Board games for everyone!"
                },
                new ActivityType
                {
                    Id = 3,
                    Name = "Tournament",
                    Abbr = "TOU",
                    Description = "A board or card game competition"
                },
                new ActivityType
                {
                    Id = 4,
                    Name = "Demos",
                    Abbr = "DEM",
                    Description = "Show your brand new project to the community"
                },
                new ActivityType
                {
                    Id = 5,
                    Name = "Live action role-playing",
                    Abbr = "LARP",
                    Description = "Role-play games in live action"
                }

            };
        }
    }
}
