using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.Commands.Contracts
{
    public interface IActivityStatusCommands
    {
        List<ActivityStatusDto> AllActivityStatusQuery();
    }
}
