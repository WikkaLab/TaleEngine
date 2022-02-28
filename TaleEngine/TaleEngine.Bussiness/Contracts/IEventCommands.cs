using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IEventCommands
    {
        List<EventDto> EventsNoFilterQuery();
        EventDto EventQuery(int eventId);
    }
}
