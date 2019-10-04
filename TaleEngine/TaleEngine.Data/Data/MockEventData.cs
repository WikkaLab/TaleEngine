using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class MockEventData
    {
        public static List<Event> MockEvents()
        {
            return new List<Event>
            {
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "The ultimate event"
                }
            };
        }
    }
}
