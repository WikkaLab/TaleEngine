using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class EditionDomainService : IEditionDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditionDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EditionDaysModel GetEditionDays(int editionId)
        {
            var edition = _unitOfWork.EditionRepository.GetById(editionId);

            if (edition == null)
            {
                return null;
            }

            var editionDays = GetAllDaysFromRange(edition.DateInit, edition.DateEnd);

            var editionDaysDto = new EditionDaysModel
            {
                EditionDays = editionDays
            };

            return editionDaysDto;
        }

        public EditionModel GetLastOrCurrentEdition(int ofEvent)
        {
            var edition = _unitOfWork.EditionRepository.GetLastEditionInEvent(ofEvent);

            if (edition != null)
            {
                return EditionMapper.Map(edition);
            }

            return null;
        }

        private List<DateTime> GetAllDaysFromRange(DateTime init, DateTime end)
        {
            List<DateTime> days = new List<DateTime>();

            TimeSpan editionDuration = end - init;

            for (int i = 0; i <= editionDuration.Days; i++)
            {
                days.Add(init.AddDays(i));
            }

            return days;
        }

    }
}
