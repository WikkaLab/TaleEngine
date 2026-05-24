using System;
using Microsoft.AspNetCore.Mvc;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportingController : Controller
    {
        private readonly IReportingQueries _queries;

        public ReportingController(IReportingQueries queries)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpPut("[action]")]
        public IActionResult GetDashboardMetrics([FromBody] ReportingFilterRequest request)
        {
            var result = _queries.DashboardMetricsQuery(request);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult GetActivityHistory([FromBody] ReportingFilterRequest request)
        {
            var result = _queries.ActivityHistoryQuery(request);

            if (result == null || result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{userId}/{editionId}")]
        public IActionResult GetUserHistory(int userId, int editionId, [FromQuery] DateTime? dateFrom = null, [FromQuery] DateTime? dateTo = null)
        {
            var result = _queries.UserHistoryQuery(userId, editionId, dateFrom, dateTo);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult ExportDashboardExcel([FromBody] ReportingFilterRequest request)
        {
            var result = _queries.ExportDashboardExcelQuery(request);

            if (result == null || result.Content == null || result.Content.Length == 0)
            {
                return NoContent();
            }

            return File(result.Content, result.ContentType, result.FileName);
        }
    }
}
