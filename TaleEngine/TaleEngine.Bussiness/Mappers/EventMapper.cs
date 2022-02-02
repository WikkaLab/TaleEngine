using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Commands.Mappers
{
    public static class EventMapper
    {
        public static EventEntity Map(EventModel eventModel)
        {
            return new EventEntity
            {
                Id = eventModel.Id,
                Title = eventModel.Title
            };
        }

        public static EventModel Map(EventEntity eventEntity)
        {
            return new EventModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title
            };
        }
    }
}
