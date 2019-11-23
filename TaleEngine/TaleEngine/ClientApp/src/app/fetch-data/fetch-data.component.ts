import { Component } from '@angular/core';
import { ActivityDto } from '../models/activity-dto';
import { ActivityService } from '../../services/activity-service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public activities: ActivityDto[];

    activityService: ActivityService;

    constructor(activityService: ActivityService) {
        this.activityService = activityService;

        var editionId = 3;

        this.activityService.getActiveActivities(editionId)
            .subscribe(result => {
              this.activities = result;
            }, error => console.error(error));
    }

    deleteActivity() {
        var activityId = 12;

        this.activityService.deleteActivity(activityId)
            .subscribe((result) => {
                console.log(result);
            }, error => console.error(error));
    }
}
