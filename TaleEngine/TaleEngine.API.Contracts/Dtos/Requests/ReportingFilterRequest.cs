using System;

namespace TaleEngine.API.Contracts.Dtos.Requests
{
    public class ReportingFilterRequest
    {
        public int EditionId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 20;
    }
}
