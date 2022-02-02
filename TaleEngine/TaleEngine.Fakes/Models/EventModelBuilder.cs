using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TaleEngine.Fakes.Models
{
    [ExcludeFromCodeCoverage]
    public static class EventModelBuilder
    {
        public static EventModel BuildEventModel()
        {
            var faker = new Faker();

            var model = new EventModel
            {
                Id = faker.Random.Number(),
                Title = faker.Random.String2(10)
            };
            return model;
        }

        public static List<EventModel> BuildEventModelList()
        {
            return new List<EventModel>
            {
                BuildEventModel()
            };
        }
    }
}
