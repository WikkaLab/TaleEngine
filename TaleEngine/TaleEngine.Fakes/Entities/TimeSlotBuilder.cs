using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class TimeSlotBuilder
    {
        public static TimeSlotEntity BuildTimeSlot()
        {
            var faker = new Faker();

            var entity = new TimeSlotEntity
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<TimeSlotEntity> BuildTimeSlotList()
        {
            List<TimeSlotEntity> list = new List<TimeSlotEntity>
            {
                BuildTimeSlot()
            };
            return list;
        }
    }
}
