using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;

namespace TaleEngine.CQRS.Contracts
{
    public interface IReportingQueries
    {
        DashboardMetricsResult DashboardMetricsQuery(ReportingFilterRequest request);
        List<ActivityHistoryResult> ActivityHistoryQuery(ReportingFilterRequest request);
        UserHistoryResult UserHistoryQuery(int userId, int editionId, DateTime? dateFrom = null, DateTime? dateTo = null);
        ReportFileResult ExportDashboardExcelQuery(ReportingFilterRequest request);
    }
}
