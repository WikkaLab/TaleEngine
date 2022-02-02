using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Commands.Contracts
{
    public interface IEventCommands
    {
        List<EventDto> EventsNoFilterQuery();
        EventDto EventQuery(int eventId);
    }
}
