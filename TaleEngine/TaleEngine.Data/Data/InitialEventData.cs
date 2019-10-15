using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialEventData
    {
        public static List<Event> GetEventsType()
        {
            return new List<Event>
            {
                new Event
                {
                    Title = "The ultimate event"
                }
            };
        }
    }
}
