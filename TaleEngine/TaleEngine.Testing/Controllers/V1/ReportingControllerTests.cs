using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.API.Controllers.V1;
using TaleEngine.CQRS.Contracts;
using Xunit;

namespace TaleEngine.Testing.Controllers.V1
{
    [ExcludeFromCodeCoverage]
    public class ReportingControllerTests
    {
        [Fact]
        public void GetDashboardMetrics_WithResult_ReturnsOk()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 1 };
            var expected = new DashboardMetricsResult { EditionId = 1, TotalActivities = 2 };
            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.DashboardMetricsQuery(request)).Returns(expected);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.GetDashboardMetrics(request);

            // Assert
            var objectResult = result as ObjectResult;
            result.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            queries.Verify(x => x.DashboardMetricsQuery(request), Times.Once);
        }

        [Fact]
        public void GetDashboardMetrics_NullResult_ReturnsNoContent()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 1 };
            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.DashboardMetricsQuery(request)).Returns((DashboardMetricsResult)null);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.GetDashboardMetrics(request);

            // Assert
            var statusResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            statusResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            queries.Verify(x => x.DashboardMetricsQuery(request), Times.Once);
        }

        [Fact]
        public void GetActivityHistory_WithResult_ReturnsOk()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 2 };
            var expected = new List<ActivityHistoryResult>
            {
                new ActivityHistoryResult { ActivityId = 99, ActivityTitle = "History" }
            };
            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.ActivityHistoryQuery(request)).Returns(expected);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.GetActivityHistory(request);

            // Assert
            var objectResult = result as ObjectResult;
            result.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            queries.Verify(x => x.ActivityHistoryQuery(request), Times.Once);
        }

        [Fact]
        public void GetActivityHistory_EmptyResult_ReturnsNoContent()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 2 };
            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.ActivityHistoryQuery(request)).Returns(new List<ActivityHistoryResult>());

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.GetActivityHistory(request);

            // Assert
            var statusResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            statusResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            queries.Verify(x => x.ActivityHistoryQuery(request), Times.Once);
        }

        [Fact]
        public void GetUserHistory_WithResult_ReturnsOk()
        {
            // Arrange
            const int userId = 12;
            const int editionId = 4;
            DateTime? dateFrom = new DateTime(2026, 1, 1);
            DateTime? dateTo = new DateTime(2026, 2, 1);

            var expected = new UserHistoryResult { UserId = userId, EditionId = editionId };
            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.UserHistoryQuery(userId, editionId, dateFrom, dateTo)).Returns(expected);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.GetUserHistory(userId, editionId, dateFrom, dateTo);

            // Assert
            var objectResult = result as ObjectResult;
            result.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            queries.Verify(x => x.UserHistoryQuery(userId, editionId, dateFrom, dateTo), Times.Once);
        }

        [Fact]
        public void GetUserHistory_NullResult_ReturnsNotFound()
        {
            // Arrange
            const int userId = 12;
            const int editionId = 4;
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.UserHistoryQuery(userId, editionId, dateFrom, dateTo)).Returns((UserHistoryResult)null);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.GetUserHistory(userId, editionId, dateFrom, dateTo);

            // Assert
            var statusResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            statusResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
            queries.Verify(x => x.UserHistoryQuery(userId, editionId, dateFrom, dateTo), Times.Once);
        }

        [Fact]
        public void ExportDashboardExcel_WithFileResult_ReturnsFile()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 1 };
            var file = new ReportFileResult
            {
                Content = new byte[] { 1, 2, 3, 4 },
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = "reporting-test.xlsx"
            };

            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.ExportDashboardExcelQuery(request)).Returns(file);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.ExportDashboardExcel(request);

            // Assert
            var fileResult = result as FileContentResult;
            result.Should().NotBeNull();
            fileResult.Should().NotBeNull();
            fileResult.ContentType.Should().Be("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            fileResult.FileDownloadName.Should().Be("reporting-test.xlsx");
            fileResult.FileContents.Should().HaveCount(4);
            queries.Verify(x => x.ExportDashboardExcelQuery(request), Times.Once);
        }

        [Fact]
        public void ExportDashboardExcel_WithNullResult_ReturnsNoContent()
        {
            // Arrange
            var request = new ReportingFilterRequest { EditionId = 1 };
            var queries = new Mock<IReportingQueries>();
            queries.Setup(x => x.ExportDashboardExcelQuery(request)).Returns((ReportFileResult)null);

            var target = new ReportingController(queries.Object);

            // Act
            var result = target.ExportDashboardExcel(request);

            // Assert
            var statusResult = result as StatusCodeResult;
            result.Should().NotBeNull();
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            queries.Verify(x => x.ExportDashboardExcelQuery(request), Times.Once);
        }
    }
}
