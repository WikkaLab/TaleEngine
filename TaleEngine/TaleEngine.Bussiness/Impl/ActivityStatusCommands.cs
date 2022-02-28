using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl
{
    public class ActivityStatusCommands : IActivityStatusCommands
    {
        private readonly IActivityStatusService _service;

        public ActivityStatusCommands(IActivityStatusService service)
        {
            _service = service;
        }

        public List<ActivityStatusDto> AllActivityStatusQuery()
        {
            var allStatuses = _service.GetActivityStatuses();

            var dtos = ActivityStatusMapper.Map(allStatuses);

            return dtos;
        }
    }
}
