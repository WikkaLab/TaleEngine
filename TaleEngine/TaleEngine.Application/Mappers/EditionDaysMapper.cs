using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Bussiness.Contracts.Models;

namespace TaleEngine.Application.Mappers
{
    public static class EditionDaysMapper
    {
        public static EditionDaysDto Map(EditionDaysModel editionDays)
        {
            var dto = new EditionDaysDto();
            dto.EditionDays.AddRange(editionDays.EditionDays);

            return dto;
        }
    }
}
