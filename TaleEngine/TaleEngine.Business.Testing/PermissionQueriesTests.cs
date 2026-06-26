using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Moq;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class PermissionQueriesTests
    {
        private readonly Mock<IPermissionService> _serviceMock;

        public PermissionQueriesTests()
        {
            _serviceMock = new Mock<IPermissionService>();
        }

        [Fact]
        public void GetPermissionQuery_WhenPermissionExists_ShouldReturnMappedDto()
        {
            // Arrange
            const int permissionId = 6;
            _serviceMock.Setup(x => x.GetPermission(permissionId)).Returns(new PermissionEntity
            {
                Id = permissionId,
                Name = "Admin",
                Abbr = "ADM",
                Description = "Admin permission"
            });
            var target = new PermissionQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionQuery(permissionId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(permissionId);
            result.Abbr.Should().Be("ADM");
        }

        [Fact]
        public void GetPermissionQuery_WhenPermissionDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetPermission(It.IsAny<int>())).Returns((PermissionEntity)null);
            var target = new PermissionQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionQuery(9);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllPermissionsQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllPermissions()).Returns((List<PermissionEntity>)null);
            var target = new PermissionQueries(_serviceMock.Object);

            // Act
            var result = target.AllPermissionsQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllPermissionsQuery_WhenServiceReturnsEmpty_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllPermissions()).Returns(new List<PermissionEntity>());
            var target = new PermissionQueries(_serviceMock.Object);

            // Act
            var result = target.AllPermissionsQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllPermissionsQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllPermissions()).Returns(new List<PermissionEntity>
            {
                new PermissionEntity { Id = 1, Name = "Read", Abbr = "R", Description = "Read" },
                new PermissionEntity { Id = 2, Name = "Write", Abbr = "W", Description = "Write" }
            });
            var target = new PermissionQueries(_serviceMock.Object);

            // Act
            var result = target.AllPermissionsQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Name.Should().Be("Read");
        }
    }
}
