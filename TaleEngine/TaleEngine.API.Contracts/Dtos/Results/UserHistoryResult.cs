using System;
using System.Collections.Generic;

namespace TaleEngine.API.Contracts.Dtos.Results
{
    public class UserHistoryResult
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int EditionId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<UserHistoryEntryDto> Entries { get; set; }
    }
}
