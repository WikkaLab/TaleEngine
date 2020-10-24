import { Component } from '@angular/core';
import { ActivityDto } from '../../models/activity-dto';
import { ActivityChangeStatusDto } from '../../models/activity-change-status-dto';
import { ActivityService } from '../../../services/activity-service';
import { ActivityStatusEnum } from '../../models/enums/activity-status-enum';

@Component({
    selector: 'app-management-activities',
    templateUrl: './management-activities.component.html'
})
export class ManagementActivitiesComponent {
    public activities: ActivityDto[];

    activityService: ActivityService;

    editionId: number;

    constructor(activityService: ActivityService) {
        this.activityService = activityService;

        this.editionId = 3;

        this.loadActivities(this.editionId);
    }

    loadActivities(editionId: number) {
        this.activityService.getPendingActivities(editionId)
            .subscribe(result => {
                this.activities = result;
            }, error => console.error(error));
    }

    setActivityActive(activityId: number) {
        var activeStatus = ActivityStatusEnum.ACT;

        this.changeActivityStatus(activityId, activeStatus);  
    }

    setActivityReview(activityId: number) {
        var reviewStatus = ActivityStatusEnum.REV;

        this.changeActivityStatus(activityId, reviewStatus);
    }

    changeActivityStatus(activityId: number, statusId: number) {
        var activityChangeStatusRequest = new ActivityChangeStatusDto(activityId, statusId);

        this.activityService.changeActivityStatus(activityChangeStatusRequest)
            .subscribe((result) => {
                this.loadActivities(this.editionId);
            }, error => console.error(error));
    }
}
