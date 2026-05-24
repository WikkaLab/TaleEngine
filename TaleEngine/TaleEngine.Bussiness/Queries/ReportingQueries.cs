using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class ReportingQueries : IReportingQueries
    {
        private readonly IReportingService _reportingService;

        public ReportingQueries(IReportingService reportingService)
        {
            _reportingService = reportingService ?? throw new ArgumentNullException(nameof(reportingService));
        }

        public DashboardMetricsResult DashboardMetricsQuery(ReportingFilterRequest request)
        {
            return _reportingService.GetDashboardMetrics(request);
        }

        public List<ActivityHistoryResult> ActivityHistoryQuery(ReportingFilterRequest request)
        {
            return _reportingService.GetActivityHistory(request);
        }

        public UserHistoryResult UserHistoryQuery(int userId, int editionId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            return _reportingService.GetUserHistory(userId, editionId, dateFrom, dateTo);
        }

        public ReportFileResult ExportDashboardExcelQuery(ReportingFilterRequest request)
        {
            return _reportingService.ExportDashboardExcel(request);
        }
    }
}
