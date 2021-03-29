using Bogus;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Fakes.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ActivityDtoBuilder
    {
        public static ActivityDto BuildActivityDto()
        {
            var faker = new Faker();

            var dto = new ActivityDto
            {
                Id = faker.Random.Number(),
                Places = faker.Random.Number(),
                Image = faker.Person.Avatar,
                ActivityEnd = faker.Date.Recent().Date.ToString(),
                ActivityStart = faker.Date.Recent().Date.ToString(),
                Description = faker.Random.String2(10),
                StatusId = faker.Random.Number(),
                Title = faker.Random.String2(10),
                TypeId = faker.Random.Number(),
                TimeSlotId = faker.Random.Number()
            };
            return dto;
        }

        public static ActivityStatusDto BuildActivityStatusDto()
        {
            var faker = new Faker();

            var dto = new ActivityStatusDto
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return dto;
        }

        public static ActivityTypeDto BuildActivityTypeDto()
        {
            var faker = new Faker();

            var dto = new ActivityTypeDto
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return dto;
        }
    }
}
