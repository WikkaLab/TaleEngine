using System;
using System.Collections.Generic;
using System.Text;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IActivityDomainService
    {
        List<ActivityDto> GetActivitiesOfEvent();
    }
}
