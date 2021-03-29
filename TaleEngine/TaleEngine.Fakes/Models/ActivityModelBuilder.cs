using Bogus;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Fakes.Models
{
    [ExcludeFromCodeCoverage]
    public class ActivityModelBuilder
    {
        public static ActivityModel BuildActivityModel()
        {
            var faker = new Faker();

            var model = new ActivityModel
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
                EndDateTime = faker.Date.Recent().Date,
                StartDateTime = faker.Date.Recent().Date,
                TimeSlotId = faker.Random.Number()
            };
            return model;
        }

        public static ActivityStatusModel BuildActivityStatusDto()
        {
            var faker = new Faker();

            var dto = new ActivityStatusModel
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return dto;
        }

        public static ActivityTypeModel BuildActivityTypeDto()
        {
            var faker = new Faker();

            var dto = new ActivityTypeModel
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return dto;
        }
    }
}
