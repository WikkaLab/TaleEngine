using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IEventService
    {
        EventEntity GetById(int id);
        List<EventEntity> GetAllEvents();
    }
}
