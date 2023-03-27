using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class ActivityStatusQueries : IActivityStatusQueries
    {
        private readonly IActivityStatusService _service;

        public ActivityStatusQueries(IActivityStatusService service)
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
