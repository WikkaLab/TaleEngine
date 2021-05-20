using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public class ActivityBuilder
    {
        public static Activity BuildActivity()
        {
            var faker = new Faker();

            var entity = new Activity
            {
                Id = faker.Random.Number(),
                Places = faker.Random.Number(),
                Image = faker.Person.Avatar,
                Description = faker.Random.String2(10),
                StatusId = faker.Random.Number(),
                Title = faker.Random.String2(10),
                TypeId = faker.Random.Number(),
                EndDateTime = faker.Date.Recent().Date,
                StartDateTime = faker.Date.Recent().Date,
                TimeSlotId = faker.Random.Number(),
            };
            return entity;
        }

        public static List<Activity> BuildActivityList()
        {
            var list = new List<Activity>
            {
                BuildActivity()
            };
            return list;
        }

        public static ActivityStatus BuildActivityStatus()
        {
            var faker = new Faker();

            var entity = new ActivityStatus
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<ActivityStatus> BuildActivityStatusList()
        {
            var list = new List<ActivityStatus>
            {
                BuildActivityStatus()
            };
            return list;
        }

        public static ActivityType BuildActivityType()
        {
            var faker = new Faker();

            var entity = new ActivityType
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<ActivityType> BuildActivityTypeList()
        {
            var list = new List<ActivityType>
            {
                BuildActivityType()
            };
            return list;
        }
    }
}
