using System;
using System.Collections.Generic;

namespace TaleEngine.API.Contracts.Dtos.Requests
{
    public class ActivityFilterRequest
    {
        public string Title { get; set; }
        public int TypeId { get; set; }
        public int EditionId { get; set; }
        public List<int> TimeFrames { get; set; }

        public DateTime ActivityDate { get; set; }

        public int Page { get; set; }
    }
}
