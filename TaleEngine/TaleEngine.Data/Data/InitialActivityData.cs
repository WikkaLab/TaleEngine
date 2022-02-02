using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialActivityData
    {
        public static List<ActivityEntity> GetActivities()
        {
            return new List<ActivityEntity>()
            {
                new ActivityEntity
                {
                    Title = "The most awesome activity ever",
                    Description = "An activity to play TTPRG!",
                },
                new ActivityEntity
                {
                    Title = "Second activity, games!",
                    Description = "Catan workshop",
                },
                new ActivityEntity
                {
                    Title = "Third activity",
                    Description = "Carcassone games",
                }
            };
        }
    }
}
