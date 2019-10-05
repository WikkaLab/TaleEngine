using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class MockActivityData
    {
        public static List<Activity> GetActivities()
        {
            return new List<Activity>()
            {
                new Activity
                {
                    EventId = 1,
                    Id = 1,
                    Title = "The most awesome activity ever",
                    Description = "An activity to play TTPRG!",
                    StatusId = 2,
                    TypeId = 1
                },
                new Activity
                {
                    EventId = 2,
                    Id = 2,
                    Title = "Second activity, games!",
                    Description = "Catan workshop",
                    StatusId = 2,
                    TypeId = 2
                },
                new Activity
                {
                    EventId = 1,
                    Id = 3,
                    Title = "Third activity",
                    Description = "Carcassone games",
                    StatusId = 2,
                    TypeId = 2
                }
            };
        }
    }
}
