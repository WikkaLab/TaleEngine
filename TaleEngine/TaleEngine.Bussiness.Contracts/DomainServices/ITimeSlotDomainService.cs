using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface ITimeSlotDomainService
    {
        List<TimeSlotDto> GetAllTimeSlots();
    }
}
