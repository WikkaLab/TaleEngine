﻿using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V2;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.Testing.Controllers.V2
{
    [ExcludeFromCodeCoverage]
    public class TimeSlotControllerTests
    {
        [Fact]
        public void GetAllTimeSlots_Success()
        {
            // Arrange
            Mock<ITimeSlotQueries> serviceMock = new Mock<ITimeSlotQueries>();
            List<TimeSlotDto> dto = new()
            {
                new TimeSlotDto
                {
                    Id = 1,
                    Name = "TimeSlotName"
                }
            };

            serviceMock.Setup(x => x.AllTimeSlotsQuery())
                .Returns(dto);

            TimeSlotController target = new TimeSlotController(serviceMock.Object);

            // Act
            IActionResult result = target.GetTimeSlots();

            // Assert
            var resultAsObjResult = result as ObjectResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.AllTimeSlotsQuery(), Times.Once);
        }

        [Fact]
        public void GetAllTimeSlots_EmptyResult_Success()
        {
            // Arrange
            Mock<ITimeSlotQueries> serviceMock = new Mock<ITimeSlotQueries>();
            List<TimeSlotDto> dto = new();

            serviceMock.Setup(x => x.AllTimeSlotsQuery())
                .Returns(dto);

            TimeSlotController target = new TimeSlotController(serviceMock.Object);

            // Act
            IActionResult result = target.GetTimeSlots();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.AllTimeSlotsQuery(), Times.Once);
        }

        [Fact]
        public void GetAllTimeSlots_NullResult_Success()
        {
            // Arrange
            Mock<ITimeSlotQueries> serviceMock = new Mock<ITimeSlotQueries>();
            List<TimeSlotDto> dto = null;

            serviceMock.Setup(x => x.AllTimeSlotsQuery())
                .Returns(dto);

            TimeSlotController target = new TimeSlotController(serviceMock.Object);

            // Act
            IActionResult result = target.GetTimeSlots();

            // Assert
            var resultAsObjResult = result as StatusCodeResult;

            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.AllTimeSlotsQuery(), Times.Once);
        }
    }
}
