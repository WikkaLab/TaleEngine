using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialRoleData
    {
        public static List<Role> GetRoleData()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Manager",
                    Abbr = "MNG",
                    Description = "Manager of the app"
                },
                new Role
                {
                    Id = 2,
                    Name = "Operator",
                    Abbr = "OPR",
                    Description = "Operator in the app"
                },
                new Role
                {
                    Id = 3,
                    Name = "Creator",
                    Abbr = "CRT",
                    Description = "Creator content in the events"
                },
                new Role
                {
                    Id = 4,
                    Name = "User",
                    Abbr = "USR",
                    Description = "Player in the application"
                }
            };
        }
    }
}
