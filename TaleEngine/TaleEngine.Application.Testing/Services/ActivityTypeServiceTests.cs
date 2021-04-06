using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Fakes.Models;
using Xunit;

namespace TaleEngine.Application.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityTypeServiceTests
    {
        private Mock<IActivityTypeDomainService> ActivityTypeServiceMock;

        public ActivityTypeServiceTests()
        {
            ActivityTypeServiceMock = new Mock<IActivityTypeDomainService>();
        }

        [Fact]
        public void GetActivityTypes_Success()
        {
            // Arrange
            List<ActivityTypeModel> list = ActivityModelBuilder.BuildActivityTypeModelList();

            ActivityTypeServiceMock.Setup(x => x.GetAllActivityTypes())
                .Returns(list);

            ActivityTypeService service = new ActivityTypeService(
                ActivityTypeServiceMock.Object);

            // Act
            var result = service.GetActivityTypes();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetActivityTypes_ReturnsEmpty_Success()
        {
            // Arrange
            List<ActivityTypeModel> list = new();

            ActivityTypeServiceMock.Setup(x => x.GetAllActivityTypes())
                .Returns(list);

            ActivityTypeService service = new ActivityTypeService(
                ActivityTypeServiceMock.Object);

            // Act
            var result = service.GetActivityTypes();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActivityTypes_ReturnsNull_Success()
        {
            // Arrange
            List<ActivityTypeModel> list = null;

            ActivityTypeServiceMock.Setup(x => x.GetAllActivityTypes())
                .Returns(list);

            ActivityTypeService service = new ActivityTypeService(
                ActivityTypeServiceMock.Object);

            // Act
            var result = service.GetActivityTypes();

            // Assert
            result.Should().BeNull();
        }
    }
}
