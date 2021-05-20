using System.Collections.Generic;
using System.Linq;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class EventMapper
    {
        public static EventDto Map(EventModel eventModel)
        {
            if (eventModel == null) return null;

            return new EventDto
            {
                Id = eventModel.Id,
                Title = eventModel.Title
            };
        }

        public static List<EventDto> Map(List<EventModel> eventModels)
        {
            if (eventModels == null || eventModels.Count == 0) return null;

            return eventModels.Select(Map).ToList();
        }

        public static EventModel Map(EventDto eventDto)
        {
            if (eventDto == null) return null;

            return new EventModel
            {
                Title = eventDto.Title
            };
        }

        public static List<EventModel> Map(List<EventDto> eventDtos)
        {
            if (eventDtos == null) return null;

            return eventDtos.Select(Map).ToList();
        }
    }
}
