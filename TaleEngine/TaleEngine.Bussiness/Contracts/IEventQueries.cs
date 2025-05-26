using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IEventQueries
    {
        List<EventDto> EventsNoFilterQuery();
        EventDto GetEvent(int eventId);
        EditionInEventDto GetCurrentEdition(int eventId);
    }
}
