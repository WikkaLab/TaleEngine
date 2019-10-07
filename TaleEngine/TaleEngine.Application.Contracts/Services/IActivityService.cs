using System;
using System.Collections.Generic;
using System.Text;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IActivityService
    {
        List<ActivityDto> GetActivities();
    }
}
