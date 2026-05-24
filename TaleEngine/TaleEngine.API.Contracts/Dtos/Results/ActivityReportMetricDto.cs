namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class ActivityReportMetricDto
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public int Places { get; set; }
        public int EnrolledUsers { get; set; }
        public int WaitingUsers { get; set; }
        public int FavouriteUsers { get; set; }
        public decimal OccupancyRate { get; set; }
    }
}
