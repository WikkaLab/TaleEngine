using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;

namespace TaleEngine.CQRS.Contracts
{
    public interface IUserQueries
    {
        List<UserDto> AllUsersQuery();
        UserDto UserQuery(int userId);
    }
}
