import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivityDto } from '../../models/activity-dto';
import { HttpHelper } from '../../../cross/helpers/http';
import { ActivityChangeStatusDto } from '../../models/activity-change-status-dto';

@Component({
    selector: 'app-management-activities',
    templateUrl: './management-activities.component.html'
})
export class ManagementActivitiesComponent {
    public activities: ActivityDto[];

    httpClient: HttpClient;
    baseUrl: string;

    editionId: number;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;

        this.editionId = 3;

        this.loadActivities(this.editionId);
    }

    loadActivities(editionId: number) {
        this.httpClient.get<ActivityDto[]>(this.baseUrl + 'api/Activity/GetPendingActivities/' + editionId)
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

        this.httpClient.put<number>(this.baseUrl + 'api/Activity/ChangeActivityStatus',
            JSON.stringify(activityChangeStatusRequest),
            HttpHelper.JsonHeaderOptions)
            .subscribe((result) => {
                this.loadActivities(this.editionId);
            }, error => console.error(error));
    }
}
