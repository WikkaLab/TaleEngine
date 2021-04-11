using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Contracts.Models.Results;
using TaleEngine.Bussiness.Enums;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityDomainService : IActivityDomainService
    {
        private const int ACTIVITIESINHOME = 3;

        private readonly IUnitOfWork _unitOfWork;

        public ActivityDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActivityModel> GetActiveActivities(int editionId)
        {
            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            if (activeStatus == null)
            {
                return null;
            }

            var activities = _unitOfWork.ActivityRepository
                .GetActivitiesByStatus(editionId, activeStatus.Id);

            var models = ActivityMapper.Map(activities);

            return models;
        }

        public List<ActivityModel> GetPendingActivities(int editionId)
        {
            var pendingStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.PEN);

            if (pendingStatus == null)
            {
                return null;
            }

            var activities = _unitOfWork.ActivityRepository
                .GetActivitiesByStatus(editionId, pendingStatus.Id);

            var models = ActivityMapper.Map(activities);

            return models;
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

        public int CreateActivity(int editionId, ActivityModel activityModel)
        {
            var isValidData = ValidateNewActivityData(activityModel, editionId);

            if (!isValidData)
            {
                return 0;
            }

            var status = _unitOfWork.ActivityStatusRepository.GetById((int)ActivityStatusEnum.PEN);
            activityModel.StatusId = status.Id;

            var activity = ActivityMapper.Map(activityModel);
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

        public int UpdateActivity(ActivityModel activityModel)
        {
            var activity = ActivityMapper.Map(activityModel);

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

        private bool ValidateNewActivityData(ActivityModel model, int editionId)
        {
            var edition = _unitOfWork.EditionRepository.GetById(editionId);
            if (edition == null)
            {
                return false;
            }

            if (model.Places <= 0)
            {
                return false;
            }

            var type = _unitOfWork.ActivityTypeRepository.GetById(model.TypeId);
            if (type == null)
            {
                return false;
            }

            var timeSlot = _unitOfWork.TimeSlotRepository.GetById(model.TimeSlotId.Value);
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

        public ActivityFilteredResultModel GetActiveActivitiesFiltered(int type, int edition,
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

            int skipByPagination = (currentPage - 1) * activitiesPerPage;

            var activities = _unitOfWork.ActivityRepository
                .GetActiveActivitiesFiltered(activeStatus.Id, type, currentEdition.Id,
                    title, skipByPagination, activitiesPerPage);

            var models = new List<ActivityModel>();

            foreach (var act in activities)
            {
                models.Add(ActivityMapper.Map(act));
            }

            int totalActivities = _unitOfWork.ActivityRepository
                .GetTotalActivities(activeStatus.Id, type, currentEdition.Id, title);

            double actsPerPage = totalActivities / activitiesPerPage;
            var totalPages = (int)Math.Ceiling(actsPerPage);

            var result = new ActivityFilteredResultModel
            {
                Activities = models,
                CurrentPage = currentPage,
                TotalPages = totalPages
            };

            return result;
        }

        public List<ActivityModel> GetLastThreeActivities(int edition)
        {
            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var currentEdition = _unitOfWork.EditionRepository
                .GetById(edition);

            if (currentEdition == null || activeStatus == null)
            {
                return null;
            }

            var activities = _unitOfWork.ActivityRepository
                 .GetLastThreeActivities(activeStatus.Id, currentEdition.Id, ACTIVITIESINHOME);

            if (activities == null || activities.Count == 0)
            {
                return null;
            }

            var models = new List<ActivityModel>();

            foreach (var act in activities)
            {
                models.Add(ActivityMapper.Map(act));
            }

            return models;
        }

    }
}
