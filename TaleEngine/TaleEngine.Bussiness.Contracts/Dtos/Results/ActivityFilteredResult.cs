using System.Collections.Generic;

namespace TaleEngine.Bussiness.Contracts.Dtos.Results
{
    public class ActivityFilteredResult
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<ActivityDto> Activities { get; set; }

    }
}
