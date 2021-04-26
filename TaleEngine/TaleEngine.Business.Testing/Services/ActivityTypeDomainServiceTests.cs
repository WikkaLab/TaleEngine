using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityTypeDomainServiceTests
    {
        private readonly Mock<IActivityTypeRepository> _activityTypeRepositoryMock;

        public ActivityTypeDomainServiceTests()
        {
            _activityTypeRepositoryMock = new Mock<IActivityTypeRepository>();
        }

        private ActivityTypeDomainService CreateActivityTypeDomainService()
        {
            return new ActivityTypeDomainService(
                _activityTypeRepositoryMock.Object);
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<ActivityType> list = ActivityBuilder.BuildActivityTypeList();

            _activityTypeRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateActivityTypeDomainService();

            // Act
            var result = target.GetAllActivityTypes();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAll_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<ActivityType> list = null;

            _activityTypeRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateActivityTypeDomainService();

            // Act
            var result = target.GetAllActivityTypes();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAll_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<ActivityType> list = new();

            _activityTypeRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateActivityTypeDomainService();

            // Act
            var result = target.GetAllActivityTypes();

            // Assert
            result.Should().BeNull();
        }
    }
}