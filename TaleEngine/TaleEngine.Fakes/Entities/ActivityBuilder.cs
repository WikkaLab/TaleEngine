using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public class ActivityBuilder
    {

        public static ActivityEntity BuildActivity(int? editionId = null,
            int? status = null, int? type = null)
        {
            var faker = new Faker();

            var entity = new ActivityEntity
            {
                Id = faker.Random.Number(1),
                Places = faker.Random.Number(1),
                Image = faker.Person.Avatar,
                Description = faker.Random.String2(10),
                StatusId = status.HasValue ? status.Value : faker.Random.Number(5),
                Title = faker.Random.String2(10),
                TypeId = type.HasValue ? type.Value : faker.Random.Number(5),
                EndDateTime = faker.Date.Recent().Date,
                StartDateTime = faker.Date.Recent().Date,
                TimeSlotId = faker.Random.Number(1),
                EditionId = editionId.HasValue ? editionId.Value : faker.Random.Number(5)
            };
            return entity;
        }

        public static List<ActivityEntity> BuildActivityList(int? editionId = null,
            int? status = null, int? type = null)
        {
            var list = new List<ActivityEntity>
            {
                BuildActivity(editionId, status, type)
            };
            return list;
        }

        public static ActivityStatusEntity BuildActivityStatus(int? id = null)
        {
            var faker = new Faker();

            var entity = new ActivityStatusEntity
            {
                Id = id.HasValue ? id.Value : faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<ActivityStatusEntity> BuildActivityStatusList()
        {
            var list = new List<ActivityStatusEntity>
            {
                BuildActivityStatus()
            };
            return list;
        }

        public static ActivityTypeEntity BuildActivityType()
        {
            var faker = new Faker();

            var entity = new ActivityTypeEntity
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<ActivityTypeEntity> BuildActivityTypeList()
        {
            var list = new List<ActivityTypeEntity>
            {
                BuildActivityType()
            };
            return list;
        }
    }
}
