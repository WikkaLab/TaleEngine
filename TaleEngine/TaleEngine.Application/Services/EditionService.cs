using System;
using TaleEngine.Data.Contracts;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class EditionService : IEditionService
    {
        private readonly IUnitOfWork _unitOfWork;

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
