using TaleEngine.Application.Contracts.Services;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Mappers;

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
            var editionDays = _editionDomainService.GetEditionDays(editionId);

            return EditionDaysMapper.Map(editionDays);
        }
    }
}
