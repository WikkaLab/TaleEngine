﻿using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IEditionService
    {
        EditionEntity GetById(int id);
        int GetCurrentOrLastEdition(int selectedEvent);
        List<EditionEntity> GetEditions(int ofEvent);
        EditionEntity GetLastEditionInEvent(int ofEvent);
    }
}
