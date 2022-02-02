using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class EditionBuilder
    {
        public static EditionEntity BuildEdition()
        {
            var faker = new Faker();

            var entity = new EditionEntity
            {
                Id = faker.Random.Number(1),
                EventId = faker.Random.Number(),
                DateInit = faker.Date.Recent(),
                DateEnd = faker.Date.Recent()
            };
            return entity;
        }

        public static List<EditionEntity> BuildEditionList()
        {
            return new List<EditionEntity>
            {
                BuildEdition()
            };
        }
    }
}
