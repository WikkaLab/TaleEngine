using System;
using System.Collections.Generic;
using System.Linq;
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

        public EditionModel GetFutureOrCurrentEdition(int ofEvent)
        {
            if (ofEvent == 0) throw new ArgumentNullException();

            var editionsOfEvent = _unitOfWork.EditionRepository.GetEditions(ofEvent);

            if (editionsOfEvent == null || editionsOfEvent.Count == 0) return null;

            var futureOrCurrentEdition = editionsOfEvent.Where(ed => ed.DateInit.Date > DateTime.Today).FirstOrDefault();

            if (futureOrCurrentEdition == null)
            {
                futureOrCurrentEdition = _unitOfWork.EditionRepository.GetLastEditionInEvent(ofEvent);
            }

            if (futureOrCurrentEdition != null)
            {
                return EditionMapper.Map(futureOrCurrentEdition);
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
