using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Requests;

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

        public static List<ActivityDto> BuildActivityDtoList()
        {
            var list = new List<ActivityDto>
            {
                BuildActivityDto()
            };
            return list;
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

        public static List<ActivityStatusDto> BuildActivityStatusDtoList()
        {
            var list = new List<ActivityStatusDto>
            {
                BuildActivityStatusDto()
            };
            return list;
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

        public static List<ActivityTypeDto> BuildActivityTypeDtoList()
        {
            var list = new List<ActivityTypeDto>
            {
                BuildActivityTypeDto()
            };
            return list;
        }

        public static ActivityChangeStatusDto BuildActivityChangeStatusDto()
        {
            var faker = new Faker();

            var dto = new ActivityChangeStatusDto
            {
                StatusId = faker.Random.Number(),
                ActivityId = faker.Random.Number()
            };
            return dto;
        }

        public static ActivityFilterRequest BuildActivityFilterRequest()
        {
            var faker = new Faker();

            var dto = new ActivityFilterRequest
            {
                CurrentPage = faker.Random.Number(),
                EditionId = faker.Random.Number(),
                TypeId = faker.Random.Number(),
                Title = faker.Random.String2(10)
            };
            return dto;
        }
    }
}
