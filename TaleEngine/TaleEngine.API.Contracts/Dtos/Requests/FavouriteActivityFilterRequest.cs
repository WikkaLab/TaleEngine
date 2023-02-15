using System;

namespace TaleEngine.API.Contracts.Dtos.Requests
{
    public class FavouriteActivityFilterRequest : ActivityFilterRequest
    {
        public Guid UserId { get; set; }
    }
}
