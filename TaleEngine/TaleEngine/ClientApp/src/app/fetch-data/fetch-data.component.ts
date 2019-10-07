import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivityModel } from '../models/activity-model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public activities: ActivityModel[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<ActivityModel[]>(baseUrl + 'api/Activity/GetActivities').subscribe(result => {
      this.activities = result;
    }, error => console.error(error));
  }
}
