using System;
using System.Collections.Generic;

namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class ActivityHistoryResult
    {
        public int ActivityId { get; set; }
        public string ActivityTitle { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public DateTime? ActivityEndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public List<ActivityHistoryUserEntryDto> Participants { get; set; }
    }
}
