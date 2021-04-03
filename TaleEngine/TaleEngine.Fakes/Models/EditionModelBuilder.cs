using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Fakes.Models
{
    [ExcludeFromCodeCoverage]
    public static class EditionModelBuilder
    {
        public static EditionModel BuildEditionModel()
        {
            var faker = new Faker();

            var model = new EditionModel
            {
                Id = faker.Random.Number(),
                EventId = faker.Random.Number(),
                DateInit = faker.Date.Recent(),
                DateEnd = faker.Date.Recent()
            };
            return model;
        }

        public static List<EditionModel> BuildEditionModelList()
        {
            return new List<EditionModel>
            {
                BuildEditionModel()
            };
        }
    }
}
