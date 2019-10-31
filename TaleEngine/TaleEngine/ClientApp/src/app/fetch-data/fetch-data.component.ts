import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivityDto } from '../models/activity-dto';
import { HttpHelper } from '../../cross/helpers/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public activities: ActivityDto[];

    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;

        this.httpClient.get<ActivityDto[]>(this.baseUrl + 'api/Activity/GetActivities').subscribe(result => {
          this.activities = result;
        }, error => console.error(error));
    }

    deleteActivity() {
        var activityId = 12;

        this.httpClient.delete<number>(this.baseUrl + 'api/Activity/DeleteActivity/' + activityId)
            .subscribe((result) => {
                console.log(result);
            }, error => console.error(error));
    }
}
