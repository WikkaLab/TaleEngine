using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface ITimeSlotService
    {
        TimeSlotEntity GetById(int id);
        List<TimeSlotEntity> GetTimeSlots();
    }
}
