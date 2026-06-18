using System;
using System.Collections.Generic;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Queries
{
    public class LocationQueries : ILocationQueries
    {
        private readonly ILocationService _service;

        public LocationQueries(ILocationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public LocationDto GetLocationQuery(int locationId)
        {
            var entity = _service.GetById(locationId);
            return LocationMapper.Map(entity);
        }

        public List<LocationDto> LocationsByEditionQuery(int editionId)
        {
            var entities = _service.GetByEdition(editionId);

            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            return LocationMapper.Map(entities);
        }
    }
}
