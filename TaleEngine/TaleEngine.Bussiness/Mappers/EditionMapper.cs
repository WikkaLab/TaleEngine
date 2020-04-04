using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Bussiness.Mappers
{
    public static class EditionMapper
    {
        public static Edition Map(EditionModel editionModel)
        {
            return new Edition
            {
                DateEnd = editionModel.DateEnd,
                DateInit = editionModel.DateInit,
                EventId = editionModel.EventId
            };
        }

        public static EditionModel Map(Edition editionEntity)
        {
            return new EditionModel
            {
                Id = editionEntity.Id,
                DateEnd = editionEntity.DateEnd,
                DateInit = editionEntity.DateInit,
                EventId = editionEntity.EventId
            };
        }
    }
}
