using System;

namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class UserHistoryEntryDto
    {
        public int ActivityId { get; set; }
        public string ActivityTitle { get; set; }
        public string RelationType { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public DateTime? ActivityEndDate { get; set; }
    }
}
