using System;
using System.Collections.Generic;
using System.Linq;
using TaleEngine.Aggregates.ActivityAggregate;
using TaleEngine.Cross.Enums;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityStatusService _activityStatusService;

        private readonly int ACTIVITESINHOME = 3;

        public ActivityService(IUnitOfWork unitOfWork, IActivityStatusService activityStatusService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _activityStatusService = activityStatusService ?? throw new ArgumentNullException(nameof(activityStatusService));
        }

        public ActivityEntity GetById(int id)
        {
            var activity = _unitOfWork.ActivityRepository
                .GetById(id);

            return activity;
        }

        public List<ActivityEntity> GetActiveActivities(int editionId)
        {
            var activeStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.ACT);

            var activities = GetActivitiesByStatus(editionId, activeStatus.Id);

            return activities;
        }

        public List<ActivityEntity> GetPendingActivities(int editionId)
        {
            var pendingStatus = _unitOfWork.ActivityStatusRepository
                .GetById((int)ActivityStatusEnum.PEN);

            var activities = GetActivitiesByStatus(editionId, pendingStatus.Id);

            return activities;
        }

        public IEnumerable<ActivityEntity> GetActiveActivitiesFiltered(int typeId, int editionId,
                List<int> timeFrames, string title, int skipByPagination, int activitiesPerPage, int userFav = default)
        {
            IEnumerable<ActivityEntity> query;

            if (userFav == 0)
            {
                query = GetActiveActivitiesWithFilter(typeId, timeFrames, editionId, title);
            }
            else
            {
                query = GetFavActivitiesFiltered(typeId, editionId, timeFrames, title, userFav);
            }

            return query;
        }

        public List<ActivityEntity> GetFavouriteActivitiesByUser(int userId, int editionId)
        {
            if (userId == default || editionId == default)
            {
                return new List<ActivityEntity>();
            }

            return GetFavActivitiesFiltered(0, editionId, null, null, userId).ToList();
        }

        public bool AddFavouriteActivity(int activityId, int userId)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetById(userId);
                var activity = _unitOfWork.ActivityRepository.GetById(activityId);

                if (user == null || activity == null)
                {
                    return false;
                }

                activity = _unitOfWork.ActivityRepository.GetAllIncludeFavs(activity.EditionId)
                    .FirstOrDefault(a => a.Id == activityId);

                if (activity == null)
                {
                    return false;
                }

                if (activity.UsersFav == null)
                {
                    activity.UsersFav = new List<UserEntity>();
                }

                if (activity.UsersFav.Any(u => u.Id == userId))
                {
                    return false;
                }

                activity.UsersFav.Add(user);

                _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.ActivityRepository.Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFavouriteActivity(int activityId, int userId)
        {
            try
            {
                var activity = _unitOfWork.ActivityRepository.GetById(activityId);

                if (activity == null)
                {
                    return false;
                }

                activity = _unitOfWork.ActivityRepository.GetAllIncludeFavs(activity.EditionId)
                    .FirstOrDefault(a => a.Id == activityId);

                if (activity?.UsersFav == null)
                {
                    return false;
                }

                var userToRemove = activity.UsersFav.FirstOrDefault(u => u.Id == userId);

                if (userToRemove == null)
                {
                    return false;
                }

                activity.UsersFav.Remove(userToRemove);

                _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.ActivityRepository.Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
            if (activity == null)
                return 0;

            var activityEntity = new ActivityEntity
            {
                EditionId = editionId,
                CreateDateTime = DateTime.Now,
                Title = activity.Title,
                TypeId = activity.Type,
                StatusId = activity.Status,
                Places = activity.Places,
                Description = activity.Description,
                TimeSlotId = activity.TimeSlot,
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

        public int UpdateActivity(int id, Activity activity)
        {
            var activityEntity = _unitOfWork.ActivityRepository.GetById(id);
            if (activityEntity != null)
            {
                activityEntity.Title = activity.Title;
                activityEntity.TypeId = activity.Type;
                activityEntity.StatusId = activity.Status;
                activityEntity.Places = activity.Places;
                activityEntity.Description = activity.Description;
                activityEntity.TimeSlotId = activity.TimeSlot;

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

        public List<ActivityEntity> GetLastThreeActivities(int editionId)
        {
            var result = GetLastThreeActivities(editionId, ACTIVITESINHOME);

            return result;
        }

        #region Private methods

        private List<ActivityEntity> GetActivitiesByStatus(int editionId, int statusId)
        {
            var activities = _unitOfWork.ActivityRepository.GetAll()
                .Where(a => a.StatusId == statusId
                            && a.EditionId == editionId)
                .ToList();

            return activities;
        }

        private List<ActivityEntity> GetLastThreeActivities(int edition, int numberOfActivities)
        {
            try {

                IEnumerable<ActivityEntity> query = GetActiveActivitiesWithFilter(0, null, edition, null);

            return query
                //.OrderByDescending(a => a.CreateDateTime)
                .Take(numberOfActivities)
                .Select(a => a)
                .ToList()
                ;
            }
            catch (Exception ex) {
                var e = ex.Message;
                return null;
            }
        }

        private IEnumerable<ActivityEntity> GetActiveActivitiesWithFilter(int type, List<int> timeframes, int edition, string title)
        {
            var activeStatus = _activityStatusService
                .GetById((int)ActivityStatusEnum.ACT);

            var query = _unitOfWork.ActivityRepository.GetAll()
                .Where(a => a.EditionId == edition && a.StatusId == activeStatus.Id);

            return ApplyActivityFilters(query, type, timeframes, title);
        }

        private IEnumerable<ActivityEntity> GetFavActivitiesFiltered(int type, int editionId, List<int> timeframes, string title, int userFav)
        {
            var activeStatus = _activityStatusService
                .GetById((int)ActivityStatusEnum.ACT);

            var query = _unitOfWork.ActivityRepository.GetAllIncludeFavs(editionId)
                .Where(a => a.EditionId == editionId
                    && a.StatusId == activeStatus.Id
                    && a.UsersFav != null
                    && a.UsersFav.Any(u => u.Id == userFav));

            return ApplyActivityFilters(query, type, timeframes, title);
        }

        private IEnumerable<ActivityEntity> ApplyActivityFilters(IEnumerable<ActivityEntity> query, int type, List<int> timeframes, string title)
        {
            if (type != 0)
            {
                query = query.Where(a => a.TypeId == type);
            }

            if (timeframes != null && timeframes.Any())
            {
                query = query.Where(a => timeframes.Contains(a.TimeSlotId));
            }

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(a => !string.IsNullOrEmpty(a.Title) && a.Title.Contains(title));
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

        public bool EnrollUserInActivity(int activityId, int userId)
        {
            try
            {
                var activity = _unitOfWork.ActivityRepository.GetAllIncludeEnrollments(activityId)
                    .FirstOrDefault(a => a.Id == activityId);
                var user = _unitOfWork.UserRepository.GetById(userId);

                if (activity == null || user == null)
                    return false;

                // Check if user is already enrolled
                if (activity.UsersPlay != null && activity.UsersPlay.Any(u => u.Id == userId))
                    return false;

                // Check if user is already in waiting list
                if (activity.UsersWaitingList != null && activity.UsersWaitingList.Any(u => u.Id == userId))
                    return false;

                // Check if there are available places
                if (activity.UsersPlay == null || activity.UsersPlay.Count < activity.Places)
                {
                    // Enroll directly
                    if (activity.UsersPlay == null)
                        activity.UsersPlay = new List<UserEntity>();
                    
                    activity.UsersPlay.Add(user);
                }
                else
                {
                    // Add to waiting list
                    if (activity.UsersWaitingList == null)
                        activity.UsersWaitingList = new List<UserEntity>();
                    
                    activity.UsersWaitingList.Add(user);
                }

                _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.ActivityRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveUserFromActivity(int activityId, int userId)
        {
            try
            {
                var activity = _unitOfWork.ActivityRepository.GetAllIncludeEnrollments(activityId)
                    .FirstOrDefault(a => a.Id == activityId);
                var user = _unitOfWork.UserRepository.GetById(userId);

                if (activity == null || user == null)
                    return false;

                bool wasEnrolled = false;

                // Remove from enrolled users
                if (activity.UsersPlay != null && activity.UsersPlay.Any(u => u.Id == userId))
                {
                    activity.UsersPlay.Remove(user);
                    wasEnrolled = true;
                }

                // Remove from waiting list
                if (activity.UsersWaitingList != null && activity.UsersWaitingList.Any(u => u.Id == userId))
                {
                    activity.UsersWaitingList.Remove(user);
                }

                _unitOfWork.ActivityRepository.Update(activity);
                _unitOfWork.ActivityRepository.Save();

                // If user was enrolled, promote from waiting list
                if (wasEnrolled)
                {
                    PromoteFromWaitingList(activityId);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UserEntity> GetWaitingList(int activityId)
        {
            var activity = _unitOfWork.ActivityRepository.GetAllIncludeWaitingList(activityId)
                .FirstOrDefault(a => a.Id == activityId);

            return activity?.UsersWaitingList ?? new List<UserEntity>();
        }

        public int? GetUserPositionInWaitingList(int activityId, int userId)
        {
            var activity = _unitOfWork.ActivityRepository.GetAllIncludeWaitingList(activityId)
                .FirstOrDefault(a => a.Id == activityId);

            if (activity?.UsersWaitingList == null)
                return null;

            var position = activity.UsersWaitingList.FindIndex(u => u.Id == userId);
            return position >= 0 ? position + 1 : (int?)null;
        }

        public bool PromoteFromWaitingList(int activityId)
        {
            try
            {
                var activity = _unitOfWork.ActivityRepository.GetAllIncludeEnrollments(activityId)
                    .FirstOrDefault(a => a.Id == activityId);

                if (activity == null)
                    return false;

                // Check if there are available places and users in waiting list
                if (activity.UsersWaitingList != null && activity.UsersWaitingList.Any() &&
                    (activity.UsersPlay == null || activity.UsersPlay.Count < activity.Places))
                {
                    var firstWaitingUser = activity.UsersWaitingList.First();
                    activity.UsersWaitingList.Remove(firstWaitingUser);

                    if (activity.UsersPlay == null)
                        activity.UsersPlay = new List<UserEntity>();
                    
                    activity.UsersPlay.Add(firstWaitingUser);

                    _unitOfWork.ActivityRepository.Update(activity);
                    _unitOfWork.ActivityRepository.Save();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
