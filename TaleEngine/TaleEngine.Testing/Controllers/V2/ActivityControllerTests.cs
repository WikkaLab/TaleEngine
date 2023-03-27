using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.API.Controllers.V2;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Fakes.Dtos;
using Xunit;

namespace TaleEngine.Testing.Controllers.V2
{
    [ExcludeFromCodeCoverage]
    public class ActivityControllerTests
    {
        [Fact]
        public void GetActivities_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = new()
            {
                new ActivityDto()
            };

            queries.Setup(x => x.ActiveActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetActivities(editionId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queries.Verify(x => x.ActiveActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetActivities_EmptyResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = new();

            queries.Setup(x => x.ActiveActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.ActiveActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetActivities_NullResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = null;

            queries.Setup(x => x.ActiveActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.ActiveActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetPendingActivities_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = new()
            {
                new ActivityDto()
            };

            queries.Setup(x => x.PendingActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetPendingActivities(editionId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queries.Verify(x => x.PendingActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetPendingActivities_EmptyResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = new();

            queries.Setup(x => x.PendingActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetPendingActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.PendingActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetPendingActivities_NullResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = null;

            queries.Setup(x => x.PendingActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetPendingActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.PendingActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = new()
            {
                new ActivityDto()
            };

            queries.Setup(x => x.LastThreeActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetLastThreeActivies(editionId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            queries.Verify(x => x.LastThreeActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_EmptyResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = new();

            queries.Setup(x => x.LastThreeActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetLastThreeActivies(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.LastThreeActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_NullResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            List<ActivityDto> dto = null;

            queries.Setup(x => x.LastThreeActivitiesQuery(editionId))
                    .Returns(dto);

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.GetLastThreeActivies(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            queries.Verify(x => x.LastThreeActivitiesQuery(editionId), Times.Once);
        }

        [Fact]
        public void CreateActivity_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            ActivityDto dto = new();

            commands.Setup(x => x.CreateCommand(editionId, dto)).Verifiable();

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.CreateActivity(editionId, dto);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commands.Verify(x => x.CreateCommand(editionId, dto), Times.Once);
        }

        [Fact]
        public void UpdateActivity_Success()
        {
            // Arrange
            int updateResult = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            ActivityDto dto = new();

            commands.Setup(x => x.UpdateCommand(dto)).Verifiable();

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.UpdateActivity(dto);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commands.Verify(x => x.UpdateCommand(dto), Times.Once);
        }

        [Fact]
        public void DeleteActivity_Success()
        {
            // Arrange
            int activityId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();

            commands.Setup(x => x.DeleteCommand(activityId)).Verifiable();

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.DeleteActivity(activityId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commands.Verify(x => x.DeleteCommand(activityId), Times.Once);
        }

        [Fact]
        public void ChangeActivityStatus_Success()
        {
            // Arrange
            int statusId = 1;
            int activityId = 1;
            Mock<IActivityCommands> commands = new();
            Mock<IActivityQueries> queries = new();
            ActivityChangeStatusDto dto = new()
            {
                ActivityId = 1,
                StatusId = 1
            };

            commands.Setup(x => x.ChangeActivityStatusCommand(dto.StatusId, dto.ActivityId))
                .Verifiable();

            ActivityController target = new(commands.Object, queries.Object);

            // Act
            IActionResult result = target.ChangeActivityStatus(dto);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            commands.Verify(x => x.ChangeActivityStatusCommand(dto.StatusId, dto.ActivityId), Times.Once);
        }

        [Fact]
        public void GetActivitiesFiltered_Success()
        {
            //// Arrange
            //var request = ActivityDtoBuilder.BuildActivityFilterRequest();
            //var modelResult = ActivityDtoBuilder.BuildActivityFilteredResult();
            //Mock<IActivityCommands> commands = new();
            //Mock<IActivityQueries> queries = new();

            //queries.Setup(x => x.ActiveActivitiesFilteredQuery(request))
            //        .Returns(modelResult);

            //ActivityController target = new(commands.Object, queries.Object);

            //// Act
            //IActionResult result = target.GetActivitiesFiltered(request);

            //// Assert
            //var resultAsObjResult = result as ObjectResult;

            //result.Should().NotBeNull();
            //resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            //queries.Verify(x => x.ActiveActivitiesFilteredQuery(request), Times.Once);
        }

        [Fact]
        public void GetActivitiesFiltered_NullResult_Success()
        {
            //// Arrange
            //var request = ActivityDtoBuilder.BuildActivityFilterRequest();
            //ActivityFilteredResult modelResult = null;
            //Mock<IActivityCommands> commands = new();
            //Mock<IActivityQueries> queries = new();

            //queries.Setup(x => x.ActiveActivitiesFilteredQuery(request))
            //        .Returns(modelResult);

            //ActivityController target = new(commands.Object, queries.Object);

            //// Act
            //IActionResult result = target.GetActivitiesFiltered(request);

            //// Assert
            //var resultAsObjResult = result as StatusCodeResult;

            //result.Should().NotBeNull();
            //resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            //queries.Verify(x => x.ActiveActivitiesFilteredQuery(request), Times.Once);
        }
    }
}
