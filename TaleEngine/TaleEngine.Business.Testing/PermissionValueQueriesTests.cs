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
    public class PermissionValueQueriesTests
    {
        private readonly Mock<IPermissionValueService> _serviceMock;

        public PermissionValueQueriesTests()
        {
            _serviceMock = new Mock<IPermissionValueService>();
        }

        [Fact]
        public void GetPermissionValueQuery_WhenEntityExists_ShouldReturnMappedDto()
        {
            // Arrange
            const int id = 7;
            _serviceMock.Setup(x => x.GetPermissionValue(id)).Returns(new PermissionValueEntity
            {
                Id = id,
                Name = "Allow",
                Abbr = "ALW",
                Description = "Allow permission"
            });
            var target = new PermissionValueQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionValueQuery(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            result.Abbr.Should().Be("ALW");
        }

        [Fact]
        public void GetPermissionValueQuery_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetPermissionValue(It.IsAny<int>())).Returns((PermissionValueEntity)null);
            var target = new PermissionValueQueries(_serviceMock.Object);

            // Act
            var result = target.GetPermissionValueQuery(11);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllPermissionValuesQuery_WhenServiceReturnsNull_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllPermissionValues()).Returns((List<PermissionValueEntity>)null);
            var target = new PermissionValueQueries(_serviceMock.Object);

            // Act
            var result = target.AllPermissionValuesQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllPermissionValuesQuery_WhenServiceReturnsEmpty_ShouldReturnNull()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllPermissionValues()).Returns(new List<PermissionValueEntity>());
            var target = new PermissionValueQueries(_serviceMock.Object);

            // Act
            var result = target.AllPermissionValuesQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void AllPermissionValuesQuery_WhenServiceReturnsItems_ShouldReturnMappedDtos()
        {
            // Arrange
            _serviceMock.Setup(x => x.GetAllPermissionValues()).Returns(new List<PermissionValueEntity>
            {
                new PermissionValueEntity { Id = 1, Name = "Allow", Abbr = "ALW", Description = "Allow" },
                new PermissionValueEntity { Id = 2, Name = "Deny", Abbr = "DEN", Description = "Deny" }
            });
            var target = new PermissionValueQueries(_serviceMock.Object);

            // Act
            var result = target.AllPermissionValuesQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[1].Name.Should().Be("Deny");
        }
    }
}
