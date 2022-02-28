using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Fakes.Dtos
{
    [ExcludeFromCodeCoverage]
    public static class EventDtoBuilder
    {
        public static EventDto BuildEventDto()
        {
            var faker = new Faker();

            var dto = new EventDto
            {
                Id = faker.Random.Number(),
                Title = faker.Random.String2(10)
            };
            return dto;
        }

        public static List<EventDto> BuildEventDtoList()
        {
            var list = new List<EventDto>
            {
                BuildEventDto()
            };
            return list;
        }
    }
}