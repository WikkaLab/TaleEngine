using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Dtos;
using TaleEngine.Bussiness.Enums;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityDomainService : IActivityDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityDto> GetActivitiesOfEvent()
        {
            var activities = _unitOfWork.ActivityRepository.GetEventActivities(1);

            var activityDtos = new List<ActivityDto>();

            foreach (var act in activities)
            {
                activityDtos.Add(ActivityMapper.Map(act));
            }

            return activityDtos;
        }

        public int DeleteActivity(int activityId)
        {
            try
            {
                _unitOfWork.ActivityRepository.Delete(activityId);
                _unitOfWork.ActivityRepository.Save();
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        public int CreateActivity(int editionId, ActivityDto activityDto)
        {
            var activity = ActivityMapper.Map(activityDto);

            var edition = _unitOfWork.EditionRepository.GetById(editionId);

            if (edition == null)
            {
                return 0;
            }

            activity.EditionId = editionId;

            var inReviewStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.REV);
            activity.Status = inReviewStatus;

            activity.LastModificationDateTime = DateTime.Now;

            // Add logging

            try
            {
                _unitOfWork.ActivityRepository.Insert(activity);
                _unitOfWork.ActivityRepository.Save();
            }
            catch (Exception e)
            {
                return 0;
            }

            return 1;
        }

        public int UpdateActivity(ActivityDto activityDto)
        {
            var activity = ActivityMapper.Map(activityDto);

            try
            {
                _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.ActivityRepository.Save();
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }
    }
}
