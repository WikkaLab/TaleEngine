using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class EventBuilder
    {
        public static Event BuildEvent()
        {
            var faker = new Faker();

            var entity = new Event
            {
                Id = faker.Random.Number(),
                Title = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<Event> BuildEventList()
        {
            return new List<Event>
            {
                BuildEvent()
            };
        }
    }
}
