using System;
using System.Collections.Generic;

namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class DashboardMetricsResult
    {
        public int EditionId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int TotalActivities { get; set; }
        public int TotalEnrollments { get; set; }
        public int TotalWaitingList { get; set; }
        public int TotalFavourites { get; set; }
        public decimal AverageOccupancyRate { get; set; }
        public List<ActivityReportMetricDto> TopActivitiesByParticipation { get; set; }
        public List<UserParticipationMetricDto> UserParticipation { get; set; }
    }
}
