using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;
using TaleEngine.CQRS.Mappers;
using TaleEngine.Services.Contracts;

namespace TaleEngine.CQRS.Commands
{
    public class LocationCommands : ILocationCommands
    {
        private readonly ILocationService _service;

        public LocationCommands(ILocationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void CreateCommand(LocationDto locationDto)
        {
            var entity = LocationMapper.MapToEntity(locationDto);
            _service.CreateLocation(entity);
        }

        public void UpdateCommand(LocationDto locationDto)
        {
            var entity = LocationMapper.MapToEntity(locationDto);
            _service.UpdateLocation(entity);
        }

        public void DeleteCommand(int locationId)
        {
            _service.DeleteLocation(locationId);
        }
    }
}
