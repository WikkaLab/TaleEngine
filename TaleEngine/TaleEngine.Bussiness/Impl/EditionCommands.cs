using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.Commands.Impl
{
    public class EditionCommands : IEditionCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditionCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EditionDaysDto GetEditionDays(int editionId)
        {
            var edition = _unitOfWork.EditionRepository.GetById(editionId);

            if (edition == null)
            {
                return null;
            }

            var editionDays = GetAllDaysFromRange(edition.DateInit, edition.DateEnd);

            var editionDaysDto = new EditionDaysDto
            {
                EditionDays = editionDays
            };

            return editionDaysDto;
        }

        public EditionDto GetFutureOrCurrentEdition(int ofEvent)
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
