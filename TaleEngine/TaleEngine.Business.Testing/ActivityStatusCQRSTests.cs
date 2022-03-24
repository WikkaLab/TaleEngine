﻿using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.CQRS.Impl;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;
using TaleEngine.Fakes.Entities;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    [ExcludeFromCodeCoverage]
    public class ActivityStatusCQRSTests
    {
        private Mock<IActivityStatusService> activityStatusServMock;

        public ActivityStatusCQRSTests()
        {
            activityStatusServMock = new Mock<IActivityStatusService>();
        }

        [Fact]
        public void GetAll_Success()
        {
            // Arrange
            List<ActivityStatusEntity> list = ActivityBuilder.BuildActivityStatusList();

            activityStatusServMock.Setup(x => x.GetActivityStatuses())
                .Returns(list);
            var target = new ActivityStatusCommands(activityStatusServMock.Object);

            // Act
            var result = target.AllActivityStatusQuery();

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAll_RepoIsEmpty_ShouldReturnNull()
        {
            // Arrange
            List<ActivityStatusEntity> list = null;

            activityStatusServMock.Setup(x => x.GetActivityStatuses())
                .Returns(list);
            var target = new ActivityStatusCommands(activityStatusServMock.Object);

            // Act
            var result = target.AllActivityStatusQuery();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetAll_EmptyResult_ShouldReturnNull()
        {
            // Arrange
            List<ActivityStatusEntity> list = new();

            activityStatusServMock.Setup(x => x.GetActivityStatuses())
                .Returns(list);
            var target = new ActivityStatusCommands(activityStatusServMock.Object);

            // Act
            var result = target.AllActivityStatusQuery();

            // Assert
            result.Should().BeNull();
        }
    }
}
