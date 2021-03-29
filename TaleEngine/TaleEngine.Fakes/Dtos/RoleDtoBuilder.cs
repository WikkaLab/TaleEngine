using Bogus;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Fakes.Dtos
{
    [ExcludeFromCodeCoverage]
    public static class RoleDtoBuilder
    {
        public static RoleDto BuildRoleDto()
        {
            var faker = new Faker();

            var dto = new RoleDto
            {
                Id = faker.Random.Number(),
                Name = faker.Random.String2(10),
                Description = faker.Random.String2(10)
            };
            return dto;
        }
    }
}
