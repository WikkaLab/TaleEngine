﻿using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.API.Controllers.V1;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.Testing.Controllers.V1
{
    [ExcludeFromCodeCoverage]
    public class EditionControllerTests
    {
        [Fact]
        public void GetEditionDays_Success()
        {
            // Arrange
            int editionId = 1;

            EditionDaysDto dto = new()
            {
                EditionDays = new List<DateTime>()
            };

            Mock<IEditionQueries> serviceMock = new();
            serviceMock.Setup(x => x.EditionDaysQuery(editionId))
                .Returns(dto);

            EditionController target = new(serviceMock.Object);

            // Act
            var result = target.GetEditionDays(editionId);

            // Assert
            ObjectResult resultAsObjResult = result as ObjectResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            serviceMock.Verify(x => x.EditionDaysQuery(editionId), Times.Once);
        }

        [Fact]
        public void GetEditionDays_NullResult_Success()
        {
            // Arrange
            int editionId = 1;

            EditionDaysDto dto = null;

            Mock<IEditionQueries> serviceMock = new();
            serviceMock.Setup(x => x.EditionDaysQuery(editionId))
                .Returns(dto);

            EditionController target = new(serviceMock.Object);

            // Act
            var result = target.GetEditionDays(editionId);

            // Assert
            var resultAsObjResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            resultAsObjResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);

            serviceMock.Verify(x => x.EditionDaysQuery(editionId), Times.Once);
        }
    }
}
