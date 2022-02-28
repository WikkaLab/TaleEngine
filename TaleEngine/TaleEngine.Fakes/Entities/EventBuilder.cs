using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class EventBuilder
    {
        public static EventEntity BuildEvent()
        {
            var faker = new Faker();

            var entity = new EventEntity
            {
                Id = faker.Random.Number(),
                Title = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<EventEntity> BuildEventList()
        {
            return new List<EventEntity>
            {
                BuildEvent()
            };
        }
    }
}
