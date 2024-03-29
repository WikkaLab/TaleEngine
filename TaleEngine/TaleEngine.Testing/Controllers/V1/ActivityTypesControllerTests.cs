﻿using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V1;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.Testing.Controllers.V1
{
    [ExcludeFromCodeCoverage]
    public class ActivityTypesControllerTests
    {
        [Fact]
        public void GetActivityTypes_Success()
        {
            // Arrange
            Mock<IActivityTypeQueries> serviceMock = new();
            List<ActivityTypeDto> dto = new()
            {
                new ActivityTypeDto
                {
                    Id = 1,
                    Name = "StatusName"
                }
            };

            serviceMock.Setup(x => x.AllActivityTypesQuery())
                .Returns(dto);

            ActivityTypeController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivityTypes();

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.AllActivityTypesQuery(), Times.Once);
        }

        [Fact]
        public void GetActivityTypes_EmptyResult_Success()
        {
            // Arrange
            Mock<IActivityTypeQueries> serviceMock = new();
            List<ActivityTypeDto> dto = new();

            serviceMock.Setup(x => x.AllActivityTypesQuery())
                .Returns(dto);

            ActivityTypeController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivityTypes();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.AllActivityTypesQuery(), Times.Once);
        }

        [Fact]
        public void GetActivityTypes_NullResult_Success()
        {
            // Arrange
            Mock<IActivityTypeQueries> serviceMock = new();
            List<ActivityTypeDto> dto = null;

            serviceMock.Setup(x => x.AllActivityTypesQuery())
                .Returns(dto);

            ActivityTypeController target = new(serviceMock.Object);

            // Act
            IActionResult result = target.GetActivityTypes();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.AllActivityTypesQuery(), Times.Once);
        }
    }
}
