using Bogus;
using System.Collections.Generic;
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

        public static List<ActivityModel> BuildActivityModelList()
        {
            var list = new List<ActivityModel>
            {
                BuildActivityModel()
            };
            return list;
        }

        public static ActivityStatusModel BuildActivityStatusModel()
        {
            var faker = new Faker();

            var Model = new ActivityStatusModel
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return Model;
        }

        public static List<ActivityStatusModel> BuildActivityStatusModelList()
        {
            var list = new List<ActivityStatusModel>
            {
                BuildActivityStatusModel()
            };
            return list;
        }

        public static ActivityTypeModel BuildActivityTypeModel()
        {
            var faker = new Faker();

            var Model = new ActivityTypeModel
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return Model;
        }

        public static List<ActivityTypeModel> BuildActivityTypeModelList()
        {
            var list = new List<ActivityTypeModel>
            {
                BuildActivityTypeModel()
            };
            return list;
        }
    }
}
