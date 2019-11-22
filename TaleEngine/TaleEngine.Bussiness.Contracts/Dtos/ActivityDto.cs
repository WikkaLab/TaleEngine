using System;

namespace TaleEngine.Bussiness.Contracts.Dtos
{
    public class ActivityDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Places { get; set; }
        public string Image { get; set; }

        public int TimeSlotId { get; set; }

        public string ActivityStart { get; set; }
        public string ActivityEnd { get; set; }

        public int TypeId { get; set; }
        public int StatusId { get; set; }

    }
}
