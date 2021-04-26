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
        private Mock<IUnitOfWork> uowMock;
        private Mock<IActivityStatusRepository> activityStatusRepoMock;

        public ActivityStatusDomainServiceTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            activityStatusRepoMock = new Mock<IActivityStatusRepository>();
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<ActivityStatus> list = ActivityBuilder.BuildActivityStatusList();

            activityStatusRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityStatusDomainService(uowMock.Object);

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

            activityStatusRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityStatusDomainService(uowMock.Object);

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

            activityStatusRepoMock.Setup(x => x.GetAll())
                .Returns(list);
            uowMock.Setup(x => x.ActivityStatusRepository)
                .Returns(activityStatusRepoMock.Object);
            var target = new ActivityStatusDomainService(uowMock.Object);

            // Act
            var result = target.GetAllActivityStatuses();

            // Assert
            result.Should().BeNull();
        }
    }
}

