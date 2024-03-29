﻿using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IEventQueries
    {
        List<EventDto> EventsNoFilterQuery();
        EventDto EventQuery(int eventId);
    }
}
