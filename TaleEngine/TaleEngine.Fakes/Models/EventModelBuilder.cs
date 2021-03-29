using Bogus;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;

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
    }
}
