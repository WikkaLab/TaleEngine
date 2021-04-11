using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Fakes.Entities
{
    [ExcludeFromCodeCoverage]
    public static class RoleBuilder
    {
        public static Role BuildRole()
        {
            var faker = new Faker();

            var entity = new Role
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10),
                Description = faker.Random.String2(10)
            };
            return entity;
        }

        public static List<Role> BuildRoleList()
        {
            return new List<Role>
            {
                BuildRole()
            };
        }
    }
}
