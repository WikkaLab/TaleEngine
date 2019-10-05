using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Data.Data;

namespace TaleEngine.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _events; 

        public EventRepository()
        {
            _events = MockEventData.MockEvents();
        }

        public List<Event> GetAllEvents()
        {
            return _events;
        }
    }
}
