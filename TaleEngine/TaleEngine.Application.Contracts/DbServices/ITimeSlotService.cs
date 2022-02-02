using System.Collections.Generic;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface ITimeSlotService
    {
        TimeSlot GetById(int id);
        List<TimeSlot> GetTimeSlots();
    }
}
