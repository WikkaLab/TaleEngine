using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Bussiness.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class RoleMapperTests
    {
        [Fact]
        public void Role_EntityToModel()
        {
            // Arrange
            var entity = RoleBuilder.BuildRole();

            // Act
            var result = RoleMapper.Map(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
        }

        [Fact]
        public void Role_EntityToModel_IsNull()
        {
            // Arrange
            Role entity = null;

            // Act
            var result = RoleMapper.Map(entity);

            // Assert
            result.Should().Be(null);
        }

        [Fact]
        public void Role_ModelToEntity()
        {
            // Arrange
            var model = RoleModelBuilder.BuildRoleModel();

            // Act
            var result = RoleMapper.Map(model);

            // Assert
            result.Id.Should().Be(model.Id);
            result.Name.Should().Be(model.Name);
        }

        [Fact]
        public void Role_ModelToEntity_IsNull()
        {
            // Arrange
            RoleModel model = null;

            // Act
            var result = RoleMapper.Map(model);

            // Assert
            result.Should().Be(null);
        }

    }
}
