using Bogus;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;

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
    }
}
