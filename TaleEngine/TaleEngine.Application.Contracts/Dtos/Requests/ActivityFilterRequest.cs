namespace TaleEngine.Application.Contracts.Dtos.Requests
{
    public class ActivityFilterRequest
    {
        public string Title { get; set; }
        public int TypeId { get; set; }
        public int EditionId { get; set; }

        public int CurrentPage { get; set; }
    }
}
