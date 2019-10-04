using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Bussiness.Contracts
{
    public interface IEventDomainService
    {
        List<EventDto> GetEventsNoFilter();
    }
}
