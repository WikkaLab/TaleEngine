using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialRoleData
    {
        public static List<RoleEntity> GetRoleData()
        {
            return new List<RoleEntity>
            {
                new RoleEntity
                {
                    Id = 1,
                    Name = "Manager",
                    Abbr = "MNG",
                    Description = "Manager of the app",
                    EventId = 2
                },
                new RoleEntity
                {
                    Id = 2,
                    Name = "Operator",
                    Abbr = "OPR",
                    Description = "Operator in the app",
                    EventId = 2
                },
                new RoleEntity
                {
                    Id = 3,
                    Name = "Creator",
                    Abbr = "CRT",
                    Description = "Creator content in the events",
                    EventId = 2
                },
                new RoleEntity
                {
                    Id = 4,
                    Name = "User",
                    Abbr = "USR",
                    Description = "Player in the application",
                    EventId = 2
                }
            };
        }
    }
}
