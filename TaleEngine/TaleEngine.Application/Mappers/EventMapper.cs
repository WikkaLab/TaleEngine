using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class EventMapper
    {
        public static EventDto Map(EventModel eventEntity)
        {
            return new EventDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title
            };
        }

        public static EventModel Map(EventDto eventDto)
        {
            return new EventModel
            {
                Title = eventDto.Title
            };
        }
    }
}
