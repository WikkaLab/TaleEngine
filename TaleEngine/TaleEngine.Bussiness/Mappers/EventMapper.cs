using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Dtos.Mappers
{
    public static class EventMapper
    {
        public static Event Map(EventModel eventModel)
        {
            return new Event
            {
                Id = eventModel.Id,
                Title = eventModel.Title
            };
        }

        public static EventModel Map(Event eventEntity)
        {
            return new EventModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title
            };
        }
    }
}
