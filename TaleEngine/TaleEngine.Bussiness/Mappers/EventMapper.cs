using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Dtos.Mappers
{
    public static class EventMapper
    {
        public static EventDto Map(Event eventEntity)
        {
            return new EventDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title
            };
        }

        public static Event Map(EventDto eventDto)
        {
            return new Event
            {
                Title = eventDto.Title
            };
        }
    }
}
