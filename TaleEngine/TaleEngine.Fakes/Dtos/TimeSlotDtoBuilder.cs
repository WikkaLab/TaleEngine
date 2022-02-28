using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Fakes.Dtos
{
    [ExcludeFromCodeCoverage]
    public static class TimeSlotDtoBuilder
    {
        public static TimeSlotDto BuildTimeSlotDto()
        {
            var faker = new Faker();

            var dto = new TimeSlotDto
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return dto;
        }

        public static List<TimeSlotDto> BuildTimeSlotDtoList()
        {
            var list = new List<TimeSlotDto>
            {
                BuildTimeSlotDto()
            };
            return list;
        }
    }
}