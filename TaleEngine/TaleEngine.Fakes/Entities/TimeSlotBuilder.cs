using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class TimeSlotBuilder
    {
        public static TimeSlot BuildTimeSlot()
        {
            var faker = new Faker();

            var entity = new TimeSlot
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<TimeSlot> BuildTimeSlotList()
        {
            List<TimeSlot> list = new List<TimeSlot>
            {
                BuildTimeSlot()
            };
            return list;
        }
    }
}
