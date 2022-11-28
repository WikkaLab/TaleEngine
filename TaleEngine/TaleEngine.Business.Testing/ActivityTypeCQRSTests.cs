using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.CQRS.Queries;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class ActivityTypeCQRSTests
    {
        private Mock<IActivityTypeService> activityTypeServMock;

        public ActivityTypeCQRSTests()
        {
            activityTypeServMock = new Mock<IActivityTypeService>();
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<ActivityTypeEntity> list = ActivityBuilder.BuildActivityTypeList();

            activityTypeServMock.Setup(x => x.GetActivityTypes())
                .Returns(list);
            var target = new ActivityTypeQueries(activityTypeServMock.Object);

            // Act
            var result = target.AllActivityTypesQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAll_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<ActivityTypeEntity> list = null;

            activityTypeServMock.Setup(x => x.GetActivityTypes())
                .Returns(list);
            var target = new ActivityTypeQueries(activityTypeServMock.Object);

            // Act
            var result = target.AllActivityTypesQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAll_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<ActivityTypeEntity> list = new();

            activityTypeServMock.Setup(x => x.GetActivityTypes())
                .Returns(list);
            var target = new ActivityTypeQueries(activityTypeServMock.Object);

            // Act
            var result = target.AllActivityTypesQuery();

            // Assert
            result.Should().BeNull();
        }
    }
}

