using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class EditionQueries : IEditionQueries
    {
        private readonly IEditionService _service;

        public EditionQueries(IEditionService service)
        {
            _service = service;
        }

        public EditionDaysDto EditionDaysQuery(int editionId)
        {
            var edition = _service.GetById(editionId);

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

        public int FutureOrCurrentEditionQuery(int ofEvent)
        {
            if (ofEvent == 0) throw new ArgumentNullException();

            var editionsOfEvent = _service.GetEditions(ofEvent);

            if (editionsOfEvent == null || editionsOfEvent.Count == 0) return 0;

            var futureOrCurrentEdition = editionsOfEvent.Where(ed => ed.DateInit.Date > DateTime.Today).FirstOrDefault();

            if (futureOrCurrentEdition == null)
            {
                futureOrCurrentEdition = _service.GetLastEditionInEvent(ofEvent);
            }

            if (futureOrCurrentEdition != null)
            {
                return futureOrCurrentEdition.Id;
            }

            return 0;
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
