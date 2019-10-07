using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("[action]")]
        public IList<ActivityDto> GetActivities()
        {
            return _activityService.GetActivities();
        }
    }
}
