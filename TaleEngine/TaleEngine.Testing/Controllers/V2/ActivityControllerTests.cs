using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Dtos.Requests;
using TaleEngine.Application.Contracts.Dtos.Results;
using TaleEngine.Application.Contracts.Services;
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
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = new()
            {
                new ActivityDto()
            };

            serviceMock.Setup(x => x.GetActiveActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivities(editionId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetActiveActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetActivities_EmptyResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = new();

            serviceMock.Setup(x => x.GetActiveActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetActiveActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetActivities_NullResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = null;

            serviceMock.Setup(x => x.GetActiveActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetActiveActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetPendingActivities_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = new()
            {
                new ActivityDto()
            };

            serviceMock.Setup(x => x.GetPendingActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetPendingActivities(editionId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetPendingActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetPendingActivities_EmptyResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = new();

            serviceMock.Setup(x => x.GetPendingActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetPendingActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetPendingActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetPendingActivities_NullResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = null;

            serviceMock.Setup(x => x.GetPendingActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetPendingActivities(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetPendingActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = new()
            {
                new ActivityDto()
            };

            serviceMock.Setup(x => x.GetLastThreeActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetLastThreeActivies(editionId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetLastThreeActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_EmptyResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = new();

            serviceMock.Setup(x => x.GetLastThreeActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetLastThreeActivies(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetLastThreeActivities(editionId), Times.Once);
        }

        [Fact]
        public void GetLastThreeActivities_NullResult_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            List<ActivityDto> dto = null;

            serviceMock.Setup(x => x.GetLastThreeActivities(editionId))
                    .Returns(dto);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetLastThreeActivies(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetLastThreeActivities(editionId), Times.Once);
        }

        [Fact]
        public void CreateActivity_Success()
        {
            // Arrange
            int editionId = 1;
            Mock<IActivityService> serviceMock = new();
            ActivityDto dto = new();

            serviceMock.Setup(x => x.CreateActivity(editionId, dto))
                    .Returns(1);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.CreateActivity(editionId, dto);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.CreateActivity(editionId, dto), Times.Once);
        }

        [Fact]
        public void UpdateActivity_Success()
        {
            // Arrange
            int updateResult = 1;
            Mock<IActivityService> serviceMock = new();
            ActivityDto dto = new();

            serviceMock.Setup(x => x.UpdateActivity(dto))
                    .Returns(updateResult);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.UpdateActivity(dto);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.UpdateActivity(dto), Times.Once);
        }

        [Fact]
        public void DeleteActivity_Success()
        {
            // Arrange
            int activityId = 1;
            Mock<IActivityService> serviceMock = new();

            serviceMock.Setup(x => x.DeleteActivity(activityId))
                    .Returns(1);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.DeleteActivity(activityId);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.DeleteActivity(activityId), Times.Once);
        }

        [Fact]
        public void ChangeActivityStatus_Success()
        {
            // Arrange
            Mock<IActivityService> serviceMock = new();
            ActivityChangeStatusDto dto = new();

            serviceMock.Setup(x => x.ChangeActivityStatus(dto))
                    .Returns(1);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.ChangeActivityStatus(dto);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.ChangeActivityStatus(dto), Times.Once);
        }

        [Fact]
        public void GetActivitiesFiltered_Success()
        {
            // Arrange
            var request = ActivityDtoBuilder.BuildActivityFilterRequest();
            var modelResult = ActivityDtoBuilder.BuildActivityFilteredResult();
            Mock<IActivityService> serviceMock = new();

            serviceMock.Setup(x => x.GetActiveActivitiesFiltered(request))
                    .Returns(modelResult);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivitiesFiltered(request);

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetActiveActivitiesFiltered(request), Times.Once);
        }

        [Fact]
        public void GetActivitiesFiltered_NullResult_Success()
        {
            // Arrange
            var request = ActivityDtoBuilder.BuildActivityFilterRequest();
            ActivityFilteredResult modelResult = null;
            Mock<IActivityService> serviceMock = new();

            serviceMock.Setup(x => x.GetActiveActivitiesFiltered(request))
                    .Returns(modelResult);

            ActivityController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivitiesFiltered(request);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetActiveActivitiesFiltered(request), Times.Once);
        }
    }
}
