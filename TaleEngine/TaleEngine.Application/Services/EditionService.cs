using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;

namespace TaleEngine.DbServices.Services
{
    public class EditionService : IEditionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EditionEntity GetById(int id)
        {
            var edition = _unitOfWork.EditionRepository.GetById(id);

            return edition;
        }

        public int GetCurrentOrLastEdition(int selectedEvent)
        {
            if (selectedEvent == 0) throw new ArgumentNullException();

            var lastOrCurrentEdition = _unitOfWork.EditionRepository
                .GetLastEditionInEvent(selectedEvent);

            if (lastOrCurrentEdition != null)
            {
                return lastOrCurrentEdition.Id;
            }

            return 0;
        }

        public List<EditionEntity> GetEditions(int ofEvent)
        {
            var editions = _unitOfWork.EditionRepository
                .GetEditions(ofEvent);

            return editions;
        }

        public EditionEntity GetLastEditionInEvent(int ofEvent)
        {
            var lastOrCurrentEdition = _unitOfWork.EditionRepository
               .GetLastEditionInEvent(ofEvent);

            return lastOrCurrentEdition;
        }
    }
}
