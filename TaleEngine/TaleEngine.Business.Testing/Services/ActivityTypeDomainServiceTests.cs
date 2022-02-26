//using FluentAssertions;
//using Moq;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using TaleEngine.Data.Contracts;
//using TaleEngine.Data.Contracts.Entities;
//using TaleEngine.Data.Contracts.Repositories;
//using TaleEngine.Fakes.Entities;
//using Xunit;

//namespace TaleEngine.Business.Testing.Services
//{
//    [ExcludeFromCodeCoverage]
//    public class ActivityTypeDomainServiceTests
//    {
//        private Mock<IUnitOfWork> uowMock;
//        private Mock<IActivityTypeRepository> activityTypeRepoMock;

//        public ActivityTypeDomainServiceTests()
//        {
//            uowMock = new Mock<IUnitOfWork>();
//            activityTypeRepoMock = new Mock<IActivityTypeRepository>();
//        }

//        [Fact]
//        public void GetAll_Success()
//        {
//            // Arrange
//            List<ActivityTypeEntity> list = ActivityBuilder.BuildActivityTypeList();

//            activityTypeRepoMock.Setup(x => x.GetAll())
//                .Returns(list);
//            uowMock.Setup(x => x.ActivityTypeRepository)
//                .Returns(activityTypeRepoMock.Object);
//            var target = new ActivityTypeCommands(uowMock.Object);

//            // Act
//            var result = target.GetAllActivityTypes();

//            // Assert
//            result.Should().NotBeNull();
//            result.Should().NotBeEmpty();
//        }

//        [Fact]
//        public void GetAll_RepoIsEmpty_ShouldReturnNull()
//        {
//            // Arrange
//            List<ActivityTypeEntity> list = null;

//            activityTypeRepoMock.Setup(x => x.GetAll())
//                .Returns(list);
//            uowMock.Setup(x => x.ActivityTypeRepository)
//                .Returns(activityTypeRepoMock.Object);
//            var target = new ActivityTypeCommands(uowMock.Object);

//            // Act
//            var result = target.GetAllActivityTypes();

//            // Assert
//            result.Should().BeNull();
//        }

//        [Fact]
//        public void GetAll_EmptyResult_ShouldReturnNull()
//        {
//            // Arrange
//            List<ActivityTypeEntity> list = new();

//            activityTypeRepoMock.Setup(x => x.GetAll())
//                .Returns(list);
//            uowMock.Setup(x => x.ActivityTypeRepository)
//                .Returns(activityTypeRepoMock.Object);
//            var target = new ActivityTypeCommands(uowMock.Object);

//            // Act
//            var result = target.GetAllActivityTypes();

//            // Assert
//            result.Should().BeNull();
//        }
//    }
//}

