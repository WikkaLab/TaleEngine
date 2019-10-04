using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Data;

namespace TaleEngine.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        public List<Event> GetAllEvents()
        {
            return MockEventData.MockEvents();
        }
    }
}
