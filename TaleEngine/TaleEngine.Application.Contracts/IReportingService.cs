using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;

namespace TaleEngine.Services.Contracts
{
    public interface IReportingService
    {
        DashboardMetricsResult GetDashboardMetrics(ReportingFilterRequest request);
        List<ActivityHistoryResult> GetActivityHistory(ReportingFilterRequest request);
        UserHistoryResult GetUserHistory(int userId, int editionId, System.DateTime? dateFrom = null, System.DateTime? dateTo = null);
        ReportFileResult ExportDashboardExcel(ReportingFilterRequest request);
    }
}
