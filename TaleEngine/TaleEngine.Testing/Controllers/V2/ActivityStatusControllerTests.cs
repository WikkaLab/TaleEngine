using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace TaleEngine.Testing.Controllers.V2
{
    [ExcludeFromCodeCoverage]
    public class ActivityStatusControllerTests
    {
        [Fact]
        public void GetActivityStatuses_Success()
        {
            // Arrange
            Mock<IActivityStatusService> serviceMock = new();
            List<ActivityStatusDto> dto = new()
            {
                new ActivityStatusDto
                {
                    Id = 1,
                    Name = "StatusName"
                }
            };

            serviceMock.Setup(x => x.GetActivityStatuses())
                .Returns(dto);

            ActivityStatusController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivityStatuses();

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.GetActivityStatuses(), Times.Once);
        }

        [Fact]
        public void GetActivityStatuses_EmptyResult_Success()
        {
            // Arrange
            Mock<IActivityStatusService> serviceMock = new();
            List<ActivityStatusDto> dto = new();

            serviceMock.Setup(x => x.GetActivityStatuses())
                .Returns(dto);

            ActivityStatusController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivityStatuses();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetActivityStatuses(), Times.Once);
        }

        [Fact]
        public void GetActivityStatuses_NullResult_Success()
        {
            // Arrange
            Mock<IActivityStatusService> serviceMock = new();
            List<ActivityStatusDto> dto = null;

            serviceMock.Setup(x => x.GetActivityStatuses())
                .Returns(dto);

            ActivityStatusController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivityStatuses();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.GetActivityStatuses(), Times.Once);
        }
    }
}
