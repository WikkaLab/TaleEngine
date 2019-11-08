using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;

namespace TaleEngine.Application.Services
{
    public class EditionService : IEditionService
    {
        private readonly IEditionDomainService _editionDomainService;

        public EditionService(IEditionDomainService editionDomainService)
        {
            _editionDomainService = editionDomainService;
        }

        public EditionDaysDto GetEditionDays(int editionId)
        {
            return _editionDomainService.GetEditionDays(editionId);
        }
    }
}
