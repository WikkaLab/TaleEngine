using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.CQRS.Queries;
using TaleEngine.Services.Contracts;
using Xunit;

namespace TaleEngine.CQRS.Testing
{
    public class ReportingQueriesTests
    {
        [Fact]
        public void DashboardMetricsQuery_ShouldReturnServiceResult()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 1 };
            var expected = new DashboardMetricsResult { EditionId = 1, TotalActivities = 3 };
            var serviceMock = new Mock<IReportingService>();
            serviceMock
                .Setup(x => x.GetDashboardMetrics(request))
                .Returns(expected);

            var target = new ReportingQueries(serviceMock.Object);

            // Act
            var result = target.DashboardMetricsQuery(request);

            // Assert
            result.Should().NotBeNull();
            result.TotalActivities.Should().Be(3);
            serviceMock.Verify(x => x.GetDashboardMetrics(request), Times.Once);
        }

        [Fact]
        public void ActivityHistoryQuery_ShouldReturnServiceResult()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 2 };
            var expected = new List<ActivityHistoryResult>
            {
                new ActivityHistoryResult { ActivityId = 10, ActivityTitle = "A1" }
            };
            var serviceMock = new Mock<IReportingService>();
            serviceMock
                .Setup(x => x.GetActivityHistory(request))
                .Returns(expected);

            var target = new ReportingQueries(serviceMock.Object);

            // Act
            var result = target.ActivityHistoryQuery(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].ActivityId.Should().Be(10);
            serviceMock.Verify(x => x.GetActivityHistory(request), Times.Once);
        }

        [Fact]
        public void UserHistoryQuery_ShouldReturnServiceResult()
        {
            // Arrange
            const int userId = 5;
            const int editionId = 7;
            DateTime? dateFrom = new DateTime(2026, 1, 1);
            DateTime? dateTo = new DateTime(2026, 1, 31);

            var expected = new UserHistoryResult
            {
                UserId = userId,
                EditionId = editionId,
                Entries = new List<UserHistoryEntryDto>()
            };

            var serviceMock = new Mock<IReportingService>();
            serviceMock
                .Setup(x => x.GetUserHistory(userId, editionId, dateFrom, dateTo))
                .Returns(expected);

            var target = new ReportingQueries(serviceMock.Object);

            // Act
            var result = target.UserHistoryQuery(userId, editionId, dateFrom, dateTo);

            // Assert
            result.Should().NotBeNull();
            result.UserId.Should().Be(userId);
            result.EditionId.Should().Be(editionId);
            serviceMock.Verify(x => x.GetUserHistory(userId, editionId, dateFrom, dateTo), Times.Once);
        }

        [Fact]
        public void ExportDashboardExcelQuery_ShouldReturnServiceResult()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 3 };
            var expected = new ReportFileResult
            {
                Content = new byte[] { 1, 2, 3 },
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = "reporting.xlsx"
            };

            var serviceMock = new Mock<IReportingService>();
            serviceMock
                .Setup(x => x.ExportDashboardExcel(request))
                .Returns(expected);

            var target = new ReportingQueries(serviceMock.Object);

            // Act
            var result = target.ExportDashboardExcelQuery(request);

            // Assert
            result.Should().NotBeNull();
            result.Content.Should().HaveCount(3);
            result.FileName.Should().Be("reporting.xlsx");
            serviceMock.Verify(x => x.ExportDashboardExcel(request), Times.Once);
        }
    }
}
