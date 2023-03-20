using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Services.Contracts
{
    public interface IEventService
    {
        EventEntity GetById(int id);
        List<EventEntity> GetAllEvents();
    }
}
