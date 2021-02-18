using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }

        public List<Edition> Editions { get; set; }
    }
}
