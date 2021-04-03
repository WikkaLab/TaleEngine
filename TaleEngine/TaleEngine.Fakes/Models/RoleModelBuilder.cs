using Bogus;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Fakes.Models
{
    [ExcludeFromCodeCoverage]
    public static class RoleModelBuilder
    {
        public static RoleModel BuildRoleModel()
        {
            var faker = new Faker();

            var model = new RoleModel
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10),
                Description = faker.Random.String2(10)
            };
            return model;
        }

        public static List<RoleModel> BuildRoleModelList()
        {
            return new List<RoleModel>
            {
                BuildRoleModel()
            };
        }
    }
}
