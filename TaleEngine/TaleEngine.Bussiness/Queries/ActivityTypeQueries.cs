using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Queries
{
    public class ActivityTypeQueries : IActivityTypeQueries
    {
        private readonly IActivityTypeService _service;

        public ActivityTypeQueries(IActivityTypeService service)
        {
            _service = service;
        }

        public List<ActivityTypeDto> AllActivityTypesQuery()
        {
            var types = _service.GetActivityTypes();
            var result = ActivityTypeMapper.Map(types);
            return result;
        }
    }
}
