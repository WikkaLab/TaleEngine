using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Commands.Contracts
{
    public interface IActivityTypeCommands
    {
        List<ActivityTypeDto> AllActivityTypesQuery();
    }
}
