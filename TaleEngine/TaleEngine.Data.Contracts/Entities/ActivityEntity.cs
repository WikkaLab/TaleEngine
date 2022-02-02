using System;
using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class ActivityEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public int Places { get; set; }

        public int StatusId { get; set; }
        public ActivityStatusEntity Status { get; set; }
        public int TypeId { get; set; }
        public ActivityTypeEntity Type { get; set; }

        public int EditionId { get; set; }
        public EditionEntity Edition { get; set; }

        public int? TimeSlotId { get; set; }
        public TimeSlotEntity TimeSlot { get; set; }

        public DateTime PublicationDate { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public List<UserEntity> UsersPlay { get; set; }
        public List<UserEntity> UsersFav { get; set; }
        public List<UserEntity> UsersCreate { get; set; }

    }
}
