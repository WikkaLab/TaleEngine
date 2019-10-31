using System;

namespace TaleEngine.Bussiness.Contracts.Dtos
{
    public class ActivityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Places { get; set; }
        public string Image { get; set; }

        public int TimeSlotId { get; set; }

        //public DateTime ActivityStart { get; set; }
        //public DateTime ActivityEnd { get; set; }

        public int TypeId { get; set; }
        public int StatusId { get; set; }

    }
}
