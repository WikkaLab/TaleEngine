using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialEventData
    {
        public static List<EventEntity> GetEventsType()
        {
            return new List<EventEntity>
            {
                new EventEntity
                {
                    Title = "The ultimate event"
                }
            };
        }
    }
}
