using System.Collections.Generic;
using TaleEngine.Domain.Models;

namespace TaleEngine.DbServices.Contracts.Services
{
    public interface IActivityService
    {
        Activity GetById(int id);
        List<Activity> GetActiveActivities(int editionId);
        List<Activity> GetPendingActivities(int editionId);
        List<Activity> GetLastThreeActivities(int editionId);
        List<Activity> GetActiveActivitiesFiltered(int typeId, int editionId,
                        string title, int skipByPagination, int activitiesPerPage);

        int ChangeActivityStatus(int activityId, int statusId);
        int DeleteActivity(int activityId);
        int CreateActivity(int editionId, Activity activity);
        int UpdateActivity(Activity activity);

    }
}
