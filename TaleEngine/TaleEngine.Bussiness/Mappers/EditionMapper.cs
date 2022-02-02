using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Commands.Mappers
{
    public static class EditionMapper
    {
        public static EditionEntity Map(EditionModel editionModel)
        {
            if (editionModel == null) return null;

            return new EditionEntity
            {
                DateEnd = editionModel.DateEnd,
                DateInit = editionModel.DateInit,
                EventId = editionModel.EventId
            };
        }

        public static EditionModel Map(EditionEntity editionEntity)
        {
            if (editionEntity == null) return null;

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
