namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class UserParticipationMetricDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int EnrolledActivities { get; set; }
        public int WaitingListActivities { get; set; }
        public int FavouriteActivities { get; set; }
    }
}
