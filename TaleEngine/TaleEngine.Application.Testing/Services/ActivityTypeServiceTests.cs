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
    public class ActivityTypeServiceTests
    {
        private Mock<IUnitOfWork> mock;

        public ActivityTypeServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void GetActivityTypes_Success()
        {
            // Arrange
            List<ActivityTypeEntity> list = ActivityBuilder.BuildActivityTypeList();

            mock.Setup(x => x.ActivityTypeRepository.GetAll())
                .Returns(list);

            ActivityTypeService service = new ActivityTypeService(mock.Object);

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
            List<ActivityTypeEntity> list = new();

            mock.Setup(x => x.ActivityTypeRepository.GetAll())
                .Returns(list);

            ActivityTypeService service = new ActivityTypeService(mock.Object);

            // Act
            var result = service.GetActivityTypes();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetActivityTypes_ReturnsNull_Success()
        {
            // Arrange
            List<ActivityTypeEntity> list = null;

            mock.Setup(x => x.ActivityTypeRepository.GetAll())
                .Returns(list);

            ActivityTypeService service = new ActivityTypeService(mock.Object);

            // Act
            var result = service.GetActivityTypes();

            // Assert
            result.Should().BeNull();
        }
    }
}
