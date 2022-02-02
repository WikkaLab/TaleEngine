using System.Collections.Generic;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IEventService
    {
        Event GetById(int id);
        List<Event> GetAllEvents();

        Event GetEvent(int eventId);
        int GetCurrentOrFutureEdition(int selectedEvent);
    }
}
