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
    public class ActivityStatusServiceTests
    {
        private Mock<IActivityStatusDomainService> ActivityStatusServiceMock;

        public ActivityStatusServiceTests()
        {
            ActivityStatusServiceMock = new Mock<IActivityStatusDomainService>();
        }

        [Fact]
        public void GetActivityStatuss_Success()
        {
            // Arrange
            List<ActivityStatusModel> list = ActivityModelBuilder.BuildActivityStatusModelList();

            ActivityStatusServiceMock.Setup(x => x.GetAllActivityStatuses())
                .Returns(list);

            ActivityStatusService service = new ActivityStatusService(
                ActivityStatusServiceMock.Object);

            // Act
            var result = service.GetActivityStatuses();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetActivityStatuss_ReturnsEmpty_Success()
        {
            // Arrange
            List<ActivityStatusModel> list = new();

            ActivityStatusServiceMock.Setup(x => x.GetAllActivityStatuses())
                .Returns(list);

            ActivityStatusService service = new ActivityStatusService(
                ActivityStatusServiceMock.Object);

            // Act
            var result = service.GetActivityStatuses();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetActivityStatuss_ReturnsNull_Success()
        {
            // Arrange
            List<ActivityStatusModel> list = null;

            ActivityStatusServiceMock.Setup(x => x.GetAllActivityStatuses())
                .Returns(list);

            ActivityStatusService service = new ActivityStatusService(
                ActivityStatusServiceMock.Object);

            // Act
            var result = service.GetActivityStatuses();

            // Assert
            result.Should().BeNull();
        }
    }
}
