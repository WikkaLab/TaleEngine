namespace TaleEngine.Bussiness.Contracts.Models.Requests
{
    public class ActivityFilterRequestModel
    {
        public string Title { get; set; }
        public int TypeId { get; set; }
        public int EditionId { get; set; }

        public int CurrentPage { get; set; }
    }
}
