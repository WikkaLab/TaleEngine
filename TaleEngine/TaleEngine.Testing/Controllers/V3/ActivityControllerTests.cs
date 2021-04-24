using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Queries;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Controllers.V3;
using Xunit;

namespace TaleEngine.Testing.Controllers.V3
{
    [ExcludeFromCodeCoverage]
    public class ActivityControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IActivityQueries> _activityQueriesMock;
        private readonly Mock<ILogger<ActivityController>> _loggerMock;

        public ActivityControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _activityQueriesMock = new Mock<IActivityQueries>();
            _loggerMock = new Mock<ILogger<ActivityController>>();
        }

        [Fact]
        public void GetActivities_Success()
        {
            // Arrange
            var fakeEditionId = 123;
            var fakeDynamicResult = new List<ActivityModel>();
            _activityQueriesMock.Setup(x => x.GetActivities(It.IsAny<int>()))
                  .Returns(fakeDynamicResult);

            //Act
            var activityController = new ActivityController(_mediatorMock.Object, _activityQueriesMock.Object, _loggerMock.Object);
            var actionResult = activityController.GetActivities(fakeEditionId) as OkObjectResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}