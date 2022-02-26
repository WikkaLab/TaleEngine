using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.CQRS.Impl
{
    public class ActivityTypeCommands : IActivityTypeCommands
    {
        private readonly IActivityTypeService _service;

        public ActivityTypeCommands(IActivityTypeService service)
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
