using TaleEngine.API.Contracts.Dtos;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.CQRS.Mappers
{
    public static class EventMapper
    {
        public static EventDto Map(EventEntity eventModel)
        {
            return new EventDto
            {
                Id = eventModel.Id,
                Title = eventModel.Title
            };
        }
    }
}
