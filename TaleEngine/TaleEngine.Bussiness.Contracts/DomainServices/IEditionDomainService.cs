﻿using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IEditionDomainService
    {
        EditionDaysModel GetEditionDays(int editionId);
        EditionModel GetFutureOrCurrentEdition(int ofEvent);

    }
}
