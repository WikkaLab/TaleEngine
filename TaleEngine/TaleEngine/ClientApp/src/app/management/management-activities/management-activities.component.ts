import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivityDto } from '../../models/activity-dto';
import { HttpHelper } from '../../../cross/helpers/http';

@Component({
    selector: 'app-management-activities',
    templateUrl: './management-activities.component.html'
})
export class ManagementActivitiesComponent {
    public activities: ActivityDto[];

    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;

        var editionId = 3;

        this.httpClient.get<ActivityDto[]>(this.baseUrl + 'api/Activity/GetPendingActivities/' + editionId)
            .subscribe(result => {
                this.activities = result;
            }, error => console.error(error));
    }

    setActivityActive(activityId: number) {
        //this.httpClient.put<number>(this.baseUrl + 'api/Activity/SetActivityActive')
        console.log(activityId);
    }

    setActivityReview(activityId: number) {
        console.log(activityId);
    }
}
