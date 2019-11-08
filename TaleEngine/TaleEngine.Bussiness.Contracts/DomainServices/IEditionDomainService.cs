using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Bussiness.Contracts.DomainServices
{
    public interface IEditionDomainService
    {
        EditionDaysDto GetEditionDays(int editionId);
    }
}
