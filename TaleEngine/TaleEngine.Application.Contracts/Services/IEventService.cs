using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IEventService
    {
        List<EventDto> GetAllEvents();

        EventDto GetEvent(int eventId);
    }
}
