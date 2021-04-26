using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Bussiness.DomainServices;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Data.Contracts.Repositories;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.Business.Testing.Services
{
    [ExcludeFromCodeCoverage]
    public class ActivityStatusDomainServiceTests
    {
        private readonly Mock<IActivityStatusRepository> _activityStatusRepositoryMock;

        public ActivityStatusDomainServiceTests()
        {
            _activityStatusRepositoryMock = new Mock<IActivityStatusRepository>();
        }

        private ActivityStatusDomainService CreateActivityStatusDomainService()
        {
            return new ActivityStatusDomainService(
                _activityStatusRepositoryMock.Object);
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<ActivityStatus> list = ActivityBuilder.BuildActivityStatusList();

            _activityStatusRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateActivityStatusDomainService();

            // Act
            var result = target.GetAllActivityStatuses();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAll_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<ActivityStatus> list = null;

            _activityStatusRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateActivityStatusDomainService();

            // Act
            var result = target.GetAllActivityStatuses();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAll_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<ActivityStatus> list = new();

            _activityStatusRepositoryMock.Setup(x => x.GetAll())
                .Returns(list);

            var target = CreateActivityStatusDomainService();

            // Act
            var result = target.GetAllActivityStatuses();

            // Assert
            result.Should().BeNull();
        }
    }
}