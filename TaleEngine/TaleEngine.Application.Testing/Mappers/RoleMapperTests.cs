using FluentAssertions;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Fakes.Dtos;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Mappers
{
    [ExcludeFromCodeCoverage]
    public class RoleMapperTests
    {
        [Fact]
        public void Role_DtoToModel()
        {
            // Arrange
            var dto = RoleDtoBuilder.BuildRoleDto();

            // Act
            var result = RoleMapper.Map(dto);

            // Assert
            result.Id.Should().Be(dto.Id);
            result.Name.Should().Be(dto.Name);
        }

        [Fact]
        public void Role_DtoToModel_IsNull()
        {
            // Arrange
            RoleDto dto = null;

            // Act
            var result = RoleMapper.Map(dto);

            // Assert
            result.Should().Be(null);
        }

        [Fact]
        public void Role_ModelToDto()
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
        public void Role_ModelToDto_IsNull()
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
