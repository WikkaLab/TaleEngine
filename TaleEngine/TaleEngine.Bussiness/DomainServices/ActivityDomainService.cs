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

        public List<ActivityDto> GetActiveActivities(int editionId)
        {
            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            if (activeStatus == null)
            {
                return null;
            }

            var activities = _unitOfWork.ActivityRepository
                .GetActivitiesByStatus(editionId, activeStatus.Id);

            var activityDtos = new List<ActivityDto>();

            foreach (var act in activities)
            {
                activityDtos.Add(ActivityMapper.Map(act));
            }

            return activityDtos;
        }

        public List<ActivityDto> GetPendingActivities(int editionId)
        {
            var pendingStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.PEN);

            if (pendingStatus == null)
            {
                return null;
            }

            var activities = _unitOfWork.ActivityRepository
                .GetActivitiesByStatus(editionId, pendingStatus.Id);

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
            var isValidData = ValidateNewActivityData(activityDto, editionId);

            if (!isValidData)
            {
                return 0;
            }

            var status = _unitOfWork.ActivityStatusRepository.GetById((int)ActivityStatusEnum.PEN);
            activityDto.StatusId = status.Id;

            var activity = ActivityMapper.Map(activityDto);
            activity.EditionId = editionId;
            activity.CreateDateTime = DateTime.Now;

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

        private bool ValidateNewActivityData(ActivityDto dto, int editionId)
        {
            var edition = _unitOfWork.EditionRepository.GetById(editionId);
            if (edition == null)
            {
                return false;
            }

            if (dto.Places <= 0)
            {
                return false;
            }

            var type = _unitOfWork.ActivityTypeRepository.GetById(dto.TypeId);
            if (type == null)
            {
                return false;
            }

            var timeSlot = _unitOfWork.TimeSlotRepository.GetById(dto.TimeSlotId);
            if (timeSlot == null)
            {
                return false;
            }

            return true;
        }

        public int ChangeActivityStatus(int activityId, int statusId)
        {
            var status = _unitOfWork.ActivityStatusRepository.GetById(statusId);
            var activity = _unitOfWork.ActivityRepository.GetById(activityId);

            if (status == null || activity == null)
            {
                return 0;
            }

            activity.StatusId = status.Id;

            try
            {
                _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.ActivityRepository.Save();
            }
            catch (Exception e)
            {
                return 0;
            }

            return 1;
        }

        public List<ActivityDto> GetActiveActivitiesFiltered(int type, int edition, 
            string title, int currentPage)
        {
            int activitiesPerPage = 10;

            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var currentEdition = _unitOfWork.EditionRepository
                .GetById(edition);

            if (currentEdition == null || activeStatus == null)
            {
                return null;
            }

            int skipByPagination = currentPage * activitiesPerPage;

            var activities = _unitOfWork.ActivityRepository
                .GetActiveActivitiesFiltered(activeStatus.Id, type, currentEdition.Id, 
                    title, skipByPagination);
             
            var activityDtos = new List<ActivityDto>();

            foreach (var act in activities)
            {
                activityDtos.Add(ActivityMapper.Map(act));
            }

            return activityDtos;
        }
    }
}
