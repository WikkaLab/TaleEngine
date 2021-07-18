using System;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;
using TaleEngine.Application.Mappers;
using TaleEngine.Bussiness.Contracts.DomainServices;

namespace TaleEngine.Application.Services
{
    public class EditionService : IEditionService
    {
        private readonly IEditionDomainService _editionDomainService;

        public EditionService(IEditionDomainService editionDomainService)
        {
            _editionDomainService = editionDomainService;
        }

        public int GetCurrentOrLastEdition(int selectedEvent)
        {
            if (selectedEvent == 0) throw new ArgumentNullException();

            var lastOrCurrentEdition = _editionDomainService.GetFutureOrCurrentEdition(selectedEvent);

            if (lastOrCurrentEdition != null)
            {
                return lastOrCurrentEdition.Id;
            }

            return 0;
        }

        public EditionDaysDto GetEditionDays(int editionId)
        {
            var editionDays = _editionDomainService.GetEditionDays(editionId);

            return EditionDaysMapper.Map(editionDays);
        }
    }
}
