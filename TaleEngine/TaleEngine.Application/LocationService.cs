using System;
using System.Collections.Generic;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public LocationEntity GetById(int id)
        {
            return _unitOfWork.LocationRepository.GetById(id);
        }

        public List<LocationEntity> GetByEdition(int editionId)
        {
            return _unitOfWork.LocationRepository.GetByEdition(editionId);
        }

        public void CreateLocation(LocationEntity location)
        {
            _unitOfWork.LocationRepository.Insert(location);
            _unitOfWork.LocationRepository.Save();
        }

        public void UpdateLocation(LocationEntity location)
        {
            _unitOfWork.LocationRepository.Update(location);
            _unitOfWork.LocationRepository.Save();
        }

        public void DeleteLocation(int id)
        {
            _unitOfWork.LocationRepository.Delete(id);
            _unitOfWork.LocationRepository.Save();
        }
    }
}
