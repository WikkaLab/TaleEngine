using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class RoleBuilder
    {
        public static RoleEntity BuildRole()
        {
            var faker = new Faker();

            var entity = new RoleEntity
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10),
                Description = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<RoleEntity> BuildRoleList()
        {
            return new List<RoleEntity>
            {
                BuildRole()
            };
        }
    }
}
