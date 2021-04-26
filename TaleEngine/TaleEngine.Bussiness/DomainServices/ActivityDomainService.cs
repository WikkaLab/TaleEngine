using System;
using System.Collections.Generic;
using TaleEngine.Bussiness.Contracts.DomainServices;
using TaleEngine.Bussiness.Contracts.Models;
using TaleEngine.Bussiness.Contracts.Models.Results;
using TaleEngine.Bussiness.Enums;
using TaleEngine.Bussiness.Mappers;
using TaleEngine.Data.Contracts.Repositories;

namespace TaleEngine.Bussiness.DomainServices
{
    public class ActivityDomainService : IActivityDomainService
    {
        private const int ACTIVITIESINHOME = 3;

        private readonly IActivityRepository _activityRepository;
        private readonly IActivityStatusRepository _activityStatusRepository;
        private readonly IEditionRepository _editionRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;

        public ActivityDomainService(IActivityRepository activityRepository, IActivityStatusRepository activityStatusRepository, IActivityTypeRepository activityTypeRepository, IEditionRepository editionRepository, ITimeSlotRepository timeSlotRepository)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _activityStatusRepository = activityStatusRepository ?? throw new ArgumentNullException(nameof(activityStatusRepository));
            _activityTypeRepository = activityTypeRepository ?? throw new ArgumentNullException(nameof(activityTypeRepository));
            _editionRepository = editionRepository ?? throw new ArgumentNullException(nameof(editionRepository));
            _timeSlotRepository = timeSlotRepository ?? throw new ArgumentNullException(nameof(timeSlotRepository));
        }

        public List<ActivityModel> GetActiveActivities(int editionId)
        {
            var activeStatus = _activityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            if (activeStatus == null)
            {
                return null;
            }

            var activities = _activityRepository
                .GetActivitiesByStatus(editionId, activeStatus.Id);

            var models = ActivityMapper.Map(activities);

            return models;
        }

        public List<ActivityModel> GetPendingActivities(int editionId)
        {
            var pendingStatus = _activityStatusRepository
                .GetById((int)ActivityStatusEnum.PEN);

            if (pendingStatus == null)
            {
                return null;
            }

            var activities = _activityRepository
                .GetActivitiesByStatus(editionId, pendingStatus.Id);

            var models = ActivityMapper.Map(activities);

            return models;
        }

        public int DeleteActivity(int activityId)
        {
            try
            {
                _activityRepository.Delete(activityId);
                _activityRepository.Save();
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

            var status = _activityStatusRepository.GetById((int)ActivityStatusEnum.PEN);
            activityModel.StatusId = status.Id;

            var activity = ActivityMapper.Map(activityModel);
            activity.EditionId = editionId;
            activity.CreateDateTime = DateTime.Now;

            // Add logging

            try
            {
                _activityRepository.Insert(activity);
                _activityRepository.Save();
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
                _activityRepository.Update(activity);
                _activityRepository.Save();
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        private bool ValidateNewActivityData(ActivityModel model, int editionId)
        {
            var edition = _editionRepository.GetById(editionId);
            if (edition == null)
            {
                return false;
            }

            if (model.Places <= 0)
            {
                return false;
            }

            var type = _activityTypeRepository.GetById(model.TypeId);
            if (type == null)
            {
                return false;
            }

            var timeSlot = _timeSlotRepository.GetById(model.TimeSlotId.Value);
            if (timeSlot == null)
            {
                return false;
            }

            return true;
        }

        public int ChangeActivityStatus(int activityId, int statusId)
        {
            var status = _activityStatusRepository.GetById(statusId);
            var activity = _activityRepository.GetById(activityId);

            if (status == null || activity == null)
            {
                return 0;
            }

            activity.StatusId = status.Id;

            try
            {
                _activityRepository.Update(activity);
                _activityRepository.Save();
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

            var activeStatus = _activityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var currentEdition = _editionRepository
                .GetById(edition);

            if (currentEdition == null || activeStatus == null)
            {
                return null;
            }

            int skipByPagination = (currentPage - 1) * activitiesPerPage;

            var activities = _activityRepository
                .GetActiveActivitiesFiltered(activeStatus.Id, type, currentEdition.Id,
                    title, skipByPagination, activitiesPerPage);

            var models = ActivityMapper.Map(activities);

            int totalActivities = _activityRepository
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
            var activeStatus = _activityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var currentEdition = _editionRepository
                .GetById(edition);

            if (currentEdition == null || activeStatus == null)
            {
                return null;
            }

            var activities = _activityRepository
                 .GetLastThreeActivities(activeStatus.Id, currentEdition.Id, ACTIVITIESINHOME);

            if (activities == null || activities.Count == 0)
            {
                return null;
            }

            var models = ActivityMapper.Map(activities);

            return models;
        }
    }
}