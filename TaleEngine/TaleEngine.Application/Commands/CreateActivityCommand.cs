using MediatR;
using TaleEngine.Application.Contracts.Dtos;

namespace TaleEngine.Application.Commands
{
    public class CreateActivityCommand : IRequest<ActivityDto>
    {
        public int EditionId { get; private set; }

        public ActivityDto ActivityDto { get; private set; }

        public CreateActivityCommand(int editionId, ActivityDto activityDto)
        {
            EditionId = editionId;
            ActivityDto = activityDto;
        }
    }
}