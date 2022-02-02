using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Commands.Enums;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.DbServices.Contracts.Services;
using TaleEngine.DbServices.Mappers;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Activity GetById(int id)
        {
            var activity = _unitOfWork.ActivityRepository
                .GetById(id);

            return ActivityMapper.Map(activity);
        }

        public List<Activity> GetActiveActivities(int editionId)
        {
            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var activities = GetActivitiesByStatus(editionId, activeStatus.Id);

            var result = ActivityMapper.Map(activities);

            return result;
        }

        public List<Activity> GetPendingActivities(int editionId)
        {
            var pendingStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.PEN);

            var activities = GetActivitiesByStatus(editionId, pendingStatus.Id);

            var result = ActivityMapper.Map(activities);

            return result;
        }

        public List<Activity> GetActiveActivitiesFiltered(int typeId, int editionId,
                string title, int skipByPagination, int activitiesPerPage)
        {
            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var query = GetActiveActivitiesWithFilter(activeStatus.Id, typeId, editionId, title);

            var activities = query.Skip(skipByPagination).Take(activitiesPerPage).ToList();

            var result = ActivityMapper.Map(activities);

            return result;
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

        public int CreateActivity(int editionId, Activity activity)
        {
            var activityEntity = new ActivityEntity
            {
                EditionId = editionId,
                CreateDateTime = DateTime.Now,
                Title = activity.Title,
                TypeId = activity.TypeId,
                StatusId = activity.StatusId,
                Places = activity.Places,
                Description = activity.Description,
                TimeSlotId = activity.TimeSlotId,
                Image = activity.Image
            };

            try
            {
                _unitOfWork.ActivityRepository.Insert(activityEntity);
                _unitOfWork.ActivityRepository.Save();
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        public int UpdateActivity(Activity activity)
        {
            var activityEntity = _unitOfWork.ActivityRepository.GetById(activity.Id);
            if (activityEntity != null)
            {
                activityEntity.Title = activity.Title;
                activityEntity.TypeId = activity.TypeId;
                activityEntity.StatusId = activity.StatusId;
                activityEntity.Places = activity.Places;
                activityEntity.Description = activity.Description;
                activityEntity.TimeSlotId = activity.TimeSlotId;

                return Update(activityEntity);
            }

            return 0;
        }

        public int ChangeActivityStatus(int activityId, int statusId)
        {
            var activityEntity = _unitOfWork.ActivityRepository.GetById(activityId);
            var status = _unitOfWork.ActivityStatusRepository.GetById(statusId);

            if (activityEntity != null)
            {
                activityEntity.StatusId = status.Id;
                return Update(activityEntity);
            }
            return 0;
        }

        public List<Activity> GetLastThreeActivities(int editionId)
        {
            var activities = GetLastThreeActivities(editionId);

            var result = new List<Activity>();
            foreach (var activity in activities) { }

            return result;
        }

        #region Private methods

        private List<ActivityEntity> GetActivitiesByStatus(int editionId, int statusId)
        {
            var pendingStatus = _unitOfWork.ActivityStatusRepository
                .GetById(statusId);

            var activities = _unitOfWork.ActivityRepository.GetAll()
                .Where(a => a.StatusId == statusId
                            && a.EditionId == editionId)
                .ToList();

            return activities;
        }

        private List<ActivityEntity> GetLastThreeActivities(int status, int edition, int numberOfActivities)
        {
            var query = GetActiveActivitiesWithFilter(status, 0, edition, null);

            return query.OrderByDescending(a => a.CreateDateTime).Take(numberOfActivities).ToList();
        }

        private int GetTotalActivities(int status, int type, int edition, string title)
        {
            var query = GetActiveActivitiesWithFilter(status, type, edition, title);

            return query.ToList().Count;
        }

        private IEnumerable<ActivityEntity> GetActiveActivitiesWithFilter(int status, int type, int edition, string title)
        {
            var query = _unitOfWork.ActivityRepository.GetAll().Select(a => a).Where(a => a.EditionId == edition);
            if (status != 0)
            {
                query = query.Where(a => a.StatusId == status);
            }
            if (type != 0)
            {
                query = query.Where(a => a.TypeId == type);
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(a => a.Title.Contains(title));
            }

            return query;
        }

        private int Update(ActivityEntity activityEntity)
        {
            try
            {
                _unitOfWork.ActivityRepository.Update(activityEntity);
                _unitOfWork.ActivityRepository.Save();
            }
            catch (Exception)
            {
                return 0;
            }

            return 1;
        }

        #endregion
    }
}
