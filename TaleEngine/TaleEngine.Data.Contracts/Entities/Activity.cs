using System;
using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Activity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public int Places { get; set; }

        public int StatusId { get; set; }
        public ActivityStatus Status { get; set; }
        public int TypeId { get; set; }
        public ActivityType Type { get; set; }

        public int EditionId { get; set; }
        public Edition Edition { get; set; }

        public int? TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }

        public DateTime PublicationDate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public List<UserToActivityOperation> UsersOperations { get; set; }

        public List<UserToActivityPlay> UsersPlay { get; set; }
        public List<UserToActivityFav> UsersFav { get; set; }
        public List<UserToActivityCreate> UsersCreate { get; set; }

    }
}
