using System.Collections.Generic;

namespace TaleEngine.Bussiness.Contracts.Models.Results
{
    public class ActivityFilteredResultModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<ActivityModel> Activities { get; set; }

    }
}
