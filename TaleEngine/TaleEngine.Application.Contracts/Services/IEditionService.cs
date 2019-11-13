using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Contracts.Services
{
    public interface IEditionService
    {
        EditionDaysDto GetEditionDays(int editionId);
    }
}
