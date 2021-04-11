using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class EditionBuilder
    {
        public static Edition BuildEdition()
        {
            var faker = new Faker();

            var entity = new Edition
            {
                Id = faker.Random.Number(1),
                EventId = faker.Random.Number(),
                DateInit = faker.Date.Recent(),
                DateEnd = faker.Date.Recent()
            };
            return entity;
        }

        public static List<Edition> BuildEditionList()
        {
            return new List<Edition>
            {
                BuildEdition()
            };
        }
    }
}
