using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using TaleEngine.API.Contracts.Dtos.Requests;
using TaleEngine.API.Contracts.Dtos.Results;
using TaleEngine.Data.Contracts;
using TaleEngine.Data.Contracts.Entities;
using TaleEngine.Services.Contracts;

namespace TaleEngine.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public DashboardMetricsResult GetDashboardMetrics(ReportingFilterRequest request)
        {
            if (request == null || request.EditionId == default)
            {
                return null;
            }

            var activities = _unitOfWork.ActivityRepository
                .GetAllIncludeReportData(request.EditionId, request.DateFrom, request.DateTo);

            var activityMetrics = activities
                .Select(BuildActivityMetric)
                .OrderByDescending(a => a.EnrolledUsers)
                .ThenByDescending(a => a.WaitingUsers)
                .ThenByDescending(a => a.FavouriteUsers)
                .ToList();

            var totalActivities = activityMetrics.Count;
            var totalEnrollments = activityMetrics.Sum(a => a.EnrolledUsers);
            var totalWaitingList = activityMetrics.Sum(a => a.WaitingUsers);
            var totalFavourites = activityMetrics.Sum(a => a.FavouriteUsers);
            var averageOccupancyRate = totalActivities == 0
                ? 0
                : Math.Round(activityMetrics.Average(a => a.OccupancyRate), 2);

            var userParticipation = BuildUserParticipationMetrics(activities);

            return new DashboardMetricsResult
            {
                EditionId = request.EditionId,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                TotalActivities = totalActivities,
                TotalEnrollments = totalEnrollments,
                TotalWaitingList = totalWaitingList,
                TotalFavourites = totalFavourites,
                AverageOccupancyRate = averageOccupancyRate,
                TopActivitiesByParticipation = activityMetrics.Take(5).ToList(),
                UserParticipation = userParticipation
            };
        }

        public List<ActivityHistoryResult> GetActivityHistory(ReportingFilterRequest request)
        {
            if (request == null || request.EditionId == default)
            {
                return null;
            }

            var page = request.Page < 0 ? 0 : request.Page;
            var pageSize = request.PageSize <= 0 ? 20 : request.PageSize;

            var activities = _unitOfWork.ActivityRepository
                .GetAllIncludeReportData(request.EditionId, request.DateFrom, request.DateTo)
                .OrderByDescending(a => a.StartDateTime ?? a.CreateDateTime)
                .ThenByDescending(a => a.CreateDateTime)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            return activities.Select(a => new ActivityHistoryResult
            {
                ActivityId = a.Id,
                ActivityTitle = a.Title,
                ActivityStartDate = a.StartDateTime,
                ActivityEndDate = a.EndDateTime,
                CreatedAt = a.CreateDateTime,
                LastModifiedAt = a.ModificationDate,
                Participants = BuildParticipants(a)
            }).ToList();
        }

        public UserHistoryResult GetUserHistory(int userId, int editionId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            if (userId == default || editionId == default)
            {
                return null;
            }

            var user = _unitOfWork.UserRepository.GetByIdWithActivities(userId, editionId);

            if (user == null)
            {
                return null;
            }

            var entries = new List<UserHistoryEntryDto>();

            entries.AddRange(BuildUserHistoryEntries(user.ActivitiesPlay, "Enrolled", dateFrom, dateTo));
            entries.AddRange(BuildUserHistoryEntries(user.ActivitiesWaitingList, "WaitingList", dateFrom, dateTo));
            entries.AddRange(BuildUserHistoryEntries(user.ActivitiesFav, "Favourite", dateFrom, dateTo));

            entries = entries
                .OrderByDescending(e => e.ActivityStartDate)
                .ThenBy(e => e.ActivityTitle)
                .ToList();

            return new UserHistoryResult
            {
                UserId = user.Id,
                Username = user.Username,
                EditionId = editionId,
                DateFrom = dateFrom,
                DateTo = dateTo,
                Entries = entries
            };
        }

        public ReportFileResult ExportDashboardExcel(ReportingFilterRequest request)
        {
            var dashboard = GetDashboardMetrics(request);

            if (dashboard == null)
            {
                return null;
            }

            var historyRequest = new ReportingFilterRequest
            {
                EditionId = request.EditionId,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                Page = 0,
                PageSize = int.MaxValue
            };

            var activityHistory = GetActivityHistory(historyRequest) ?? new List<ActivityHistoryResult>();
            var content = BuildDashboardWorkbook(dashboard, activityHistory);

            return new ReportFileResult
            {
                Content = content,
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = $"reporting-edition-{request.EditionId}-{DateTime.UtcNow:yyyyMMddHHmmss}.xlsx"
            };
        }

        private static byte[] BuildDashboardWorkbook(DashboardMetricsResult dashboard, List<ActivityHistoryResult> activityHistory)
        {
            using var workbook = new XLWorkbook();
            var summary = workbook.Worksheets.Add("Dashboard");
            var history = workbook.Worksheets.Add("ActivityHistory");

            BuildSummarySheet(summary, dashboard);
            BuildHistorySheet(history, activityHistory);

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        private static void BuildSummarySheet(IXLWorksheet sheet, DashboardMetricsResult dashboard)
        {
            sheet.Cell(1, 1).Value = "Metric";
            sheet.Cell(1, 2).Value = "Value";

            sheet.Cell(2, 1).Value = "EditionId";
            sheet.Cell(2, 2).Value = dashboard.EditionId;
            sheet.Cell(3, 1).Value = "DateFrom";
            sheet.Cell(3, 2).Value = dashboard.DateFrom?.ToString("yyyy-MM-dd") ?? string.Empty;
            sheet.Cell(4, 1).Value = "DateTo";
            sheet.Cell(4, 2).Value = dashboard.DateTo?.ToString("yyyy-MM-dd") ?? string.Empty;
            sheet.Cell(5, 1).Value = "TotalActivities";
            sheet.Cell(5, 2).Value = dashboard.TotalActivities;
            sheet.Cell(6, 1).Value = "TotalEnrollments";
            sheet.Cell(6, 2).Value = dashboard.TotalEnrollments;
            sheet.Cell(7, 1).Value = "TotalWaitingList";
            sheet.Cell(7, 2).Value = dashboard.TotalWaitingList;
            sheet.Cell(8, 1).Value = "TotalFavourites";
            sheet.Cell(8, 2).Value = dashboard.TotalFavourites;
            sheet.Cell(9, 1).Value = "AverageOccupancyRate";
            sheet.Cell(9, 2).Value = dashboard.AverageOccupancyRate;

            sheet.Cell(11, 1).Value = "Top Activities";
            sheet.Cell(12, 1).Value = "ActivityId";
            sheet.Cell(12, 2).Value = "Title";
            sheet.Cell(12, 3).Value = "Places";
            sheet.Cell(12, 4).Value = "EnrolledUsers";
            sheet.Cell(12, 5).Value = "WaitingUsers";
            sheet.Cell(12, 6).Value = "FavouriteUsers";
            sheet.Cell(12, 7).Value = "OccupancyRate";

            var row = 13;
            foreach (var activity in dashboard.TopActivitiesByParticipation ?? Enumerable.Empty<ActivityReportMetricDto>())
            {
                sheet.Cell(row, 1).Value = activity.ActivityId;
                sheet.Cell(row, 2).Value = activity.Title;
                sheet.Cell(row, 3).Value = activity.Places;
                sheet.Cell(row, 4).Value = activity.EnrolledUsers;
                sheet.Cell(row, 5).Value = activity.WaitingUsers;
                sheet.Cell(row, 6).Value = activity.FavouriteUsers;
                sheet.Cell(row, 7).Value = activity.OccupancyRate;
                row++;
            }

            sheet.Columns().AdjustToContents();
        }

        private static void BuildHistorySheet(IXLWorksheet sheet, List<ActivityHistoryResult> history)
        {
            sheet.Cell(1, 1).Value = "ActivityId";
            sheet.Cell(1, 2).Value = "ActivityTitle";
            sheet.Cell(1, 3).Value = "ActivityStartDate";
            sheet.Cell(1, 4).Value = "ActivityEndDate";
            sheet.Cell(1, 5).Value = "CreatedAt";
            sheet.Cell(1, 6).Value = "LastModifiedAt";
            sheet.Cell(1, 7).Value = "ParticipantsCount";

            var row = 2;
            foreach (var item in history ?? new List<ActivityHistoryResult>())
            {
                sheet.Cell(row, 1).Value = item.ActivityId;
                sheet.Cell(row, 2).Value = item.ActivityTitle;
                sheet.Cell(row, 3).Value = item.ActivityStartDate?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty;
                sheet.Cell(row, 4).Value = item.ActivityEndDate?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty;
                sheet.Cell(row, 5).Value = item.CreatedAt?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty;
                sheet.Cell(row, 6).Value = item.LastModifiedAt?.ToString("yyyy-MM-dd HH:mm") ?? string.Empty;
                sheet.Cell(row, 7).Value = item.Participants?.Count ?? 0;
                row++;
            }

            sheet.Columns().AdjustToContents();
        }

        private static ActivityReportMetricDto BuildActivityMetric(ActivityEntity activity)
        {
            var enrolledUsers = activity.UsersPlay?.Count ?? 0;
            var waitingUsers = activity.UsersWaitingList?.Count ?? 0;
            var favouriteUsers = activity.UsersFav?.Count ?? 0;
            var occupancyRate = activity.Places > 0
                ? Math.Round((decimal)enrolledUsers * 100 / activity.Places, 2)
                : 0;

            return new ActivityReportMetricDto
            {
                ActivityId = activity.Id,
                Title = activity.Title,
                Places = activity.Places,
                EnrolledUsers = enrolledUsers,
                WaitingUsers = waitingUsers,
                FavouriteUsers = favouriteUsers,
                OccupancyRate = occupancyRate
            };
        }

        private static List<UserParticipationMetricDto> BuildUserParticipationMetrics(List<ActivityEntity> activities)
        {
            var metricsByUser = new Dictionary<int, UserParticipationMetricDto>();

            foreach (var activity in activities)
            {
                UpdateUserParticipation(metricsByUser, activity.UsersPlay, p => p.EnrolledActivities++);
                UpdateUserParticipation(metricsByUser, activity.UsersWaitingList, p => p.WaitingListActivities++);
                UpdateUserParticipation(metricsByUser, activity.UsersFav, p => p.FavouriteActivities++);
            }

            return metricsByUser.Values
                .OrderByDescending(p => p.EnrolledActivities)
                .ThenByDescending(p => p.FavouriteActivities)
                .ThenBy(p => p.Username)
                .Take(10)
                .ToList();
        }

        private static void UpdateUserParticipation(
            IDictionary<int, UserParticipationMetricDto> metricsByUser,
            IEnumerable<UserEntity> users,
            Action<UserParticipationMetricDto> update)
        {
            if (users == null)
            {
                return;
            }

            foreach (var user in users)
            {
                if (!metricsByUser.TryGetValue(user.Id, out var metric))
                {
                    metric = new UserParticipationMetricDto
                    {
                        UserId = user.Id,
                        Username = user.Username,
                        EnrolledActivities = 0,
                        WaitingListActivities = 0,
                        FavouriteActivities = 0
                    };
                    metricsByUser[user.Id] = metric;
                }

                update(metric);
            }
        }

        private static List<ActivityHistoryUserEntryDto> BuildParticipants(ActivityEntity activity)
        {
            var participants = new List<ActivityHistoryUserEntryDto>();

            participants.AddRange(MapUsers(activity.UsersPlay, "Enrolled"));
            participants.AddRange(MapUsers(activity.UsersWaitingList, "WaitingList"));
            participants.AddRange(MapUsers(activity.UsersFav, "Favourite"));

            return participants;
        }

        private static IEnumerable<ActivityHistoryUserEntryDto> MapUsers(IEnumerable<UserEntity> users, string relationType)
        {
            if (users == null)
            {
                return Enumerable.Empty<ActivityHistoryUserEntryDto>();
            }

            return users.Select(u => new ActivityHistoryUserEntryDto
            {
                UserId = u.Id,
                Username = u.Username,
                RelationType = relationType
            });
        }

        private static IEnumerable<UserHistoryEntryDto> BuildUserHistoryEntries(
            IEnumerable<ActivityEntity> activities,
            string relationType,
            DateTime? dateFrom,
            DateTime? dateTo)
        {
            if (activities == null)
            {
                return Enumerable.Empty<UserHistoryEntryDto>();
            }

            var query = activities.AsEnumerable();

            if (dateFrom.HasValue)
            {
                query = query.Where(a => (a.StartDateTime ?? a.CreateDateTime) >= dateFrom.Value);
            }

            if (dateTo.HasValue)
            {
                query = query.Where(a => (a.EndDateTime ?? a.StartDateTime ?? a.CreateDateTime) <= dateTo.Value);
            }

            return query.Select(a => new UserHistoryEntryDto
            {
                ActivityId = a.Id,
                ActivityTitle = a.Title,
                RelationType = relationType,
                ActivityStartDate = a.StartDateTime,
                ActivityEndDate = a.EndDateTime
            });
        }
    }
}
