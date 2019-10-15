using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialActivityData
    {
        public static List<Activity> GetActivities()
        {
            return new List<Activity>()
            {
                new Activity
                {
                    Title = "The most awesome activity ever",
                    Description = "An activity to play TTPRG!",
                },
                new Activity
                {
                    Title = "Second activity, games!",
                    Description = "Catan workshop",
                },
                new Activity
                {
                    Title = "Third activity",
                    Description = "Carcassone games",
                }
            };
        }
    }
}
