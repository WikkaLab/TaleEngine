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
    public class AssignedPermissionQueriesTests
    {
        private readonly Mock<IAssignedPermissionService> _serviceMock;

        public AssignedPermissionQueriesTests()
        {
            _serviceMock = new Mock<IAssignedPermissionService>();
        }

        [Fact]
        public void GetPermissionsByRoleQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAssignedPermissionsByRole(It.IsAny<int>())).Returns((List<AssignedPermissionEntity>)null);
            var target = new AssignedPermissionQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionsByRoleQuery(2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetPermissionsByRoleQuery_WhenServiceReturnsEmpty_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAssignedPermissionsByRole(It.IsAny<int>())).Returns(new List<AssignedPermissionEntity>());
            var target = new AssignedPermissionQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionsByRoleQuery(2);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetPermissionsByRoleQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAssignedPermissionsByRole(2)).Returns(new List<AssignedPermissionEntity>
            {
                new AssignedPermissionEntity
                {
                    Id = 1,
                    RoleId = 2,
                    PermissionId = 10,
                    PermissionValueId = 100,
                    Permission = new PermissionEntity { Id = 10, Name = "Edit", Abbr = "EDT", Description = "Edit" },
                    PermissionValue = new PermissionValueEntity { Id = 100, Name = "Allow", Abbr = "ALW", Description = "Allow" }
                }
            });
            var target = new AssignedPermissionQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionsByRoleQuery(2);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].RoleId.Should().Be(2);
            result[0].Permission.Should().NotBeNull();
            result[0].Permission.Abbr.Should().Be("EDT");
        }

        [Fact]
        public void AllAssignedPermissionsQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllAssignedPermissions()).Returns((List<AssignedPermissionEntity>)null);
            var target = new AssignedPermissionQueries(_serviceMock.Object);

            // Act
            var result = target.AllAssignedPermissionsQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllAssignedPermissionsQuery_WhenServiceReturnsEmpty_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllAssignedPermissions()).Returns(new List<AssignedPermissionEntity>());
            var target = new AssignedPermissionQueries(_serviceMock.Object);

            // Act
            var result = target.AllAssignedPermissionsQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllAssignedPermissionsQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllAssignedPermissions()).Returns(new List<AssignedPermissionEntity>
            {
                new AssignedPermissionEntity
                {
                    Id = 9,
                    RoleId = 3,
                    PermissionId = 11,
                    PermissionValueId = 22,
                    Permission = new PermissionEntity { Id = 11, Name = "Read", Abbr = "R", Description = "Read" },
                    PermissionValue = new PermissionValueEntity { Id = 22, Name = "Allow", Abbr = "ALW", Description = "Allow" }
                }
            });
            var target = new AssignedPermissionQueries(_serviceMock.Object);

            // Act
            var result = target.AllAssignedPermissionsQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].PermissionId.Should().Be(11);
            result[0].PermissionValueId.Should().Be(22);
        }
    }
}
