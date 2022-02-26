using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface ITimeSlotService
    {
        TimeSlotEntity GetById(int id);
        List<TimeSlotEntity> GetTimeSlots();
    }
}
