using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Services.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityStatusServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public ActivityStatusServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetActivityStatuss_Success()
        {
            // Arrange
            List<ActivityStatusEntity> list = ActivityBuilder.BuildActivityStatusList();

            mock.Setup(x => x.ActivityStatusRepository.GetAll())
                .Returns(list);

            ActivityStatusService service = new ActivityStatusService(mock.Object);

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
            List<ActivityStatusEntity> list = new();

            mock.Setup(x => x.ActivityStatusRepository.GetAll())
                .Returns(list);

            ActivityStatusService service = new ActivityStatusService(mock.Object);

            // Act
            var result = service.GetActivityStatuses();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetActivityStatuss_ReturnsNull_Success()
        {
            // Arrange
            List<ActivityStatusEntity> list = null;

            mock.Setup(x => x.ActivityStatusRepository.GetAll())
                .Returns(list);

            ActivityStatusService service = new ActivityStatusService(mock.Object);

            // Act
            var result = service.GetActivityStatuses();

            // Assert
            result.Should().BeNull();
        }
    }
}
