import { Component } from '@angular/core';
import { ActivityDto } from '../models/activity-dto';
import { ActivityService } from '../../services/activity-service';
import { ActivityFilterRequest } from '../models/requests/activity-filter-request';
import { ActivityFilteredResult } from '../models/activity-filtered-result';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public activities: ActivityDto[];

    activityService: ActivityService;

    pageNumber: number = 1;
    editionId: number = 3;

    totalPages: number = 0;

    activityFilterRequest: ActivityFilterRequest;

    activityFilterResult: ActivityFilteredResult;

    constructor(activityService: ActivityService) {
        this.activityService = activityService;

      this.activityFilterRequest = new ActivityFilterRequest();
      this.activityFilterRequest.currentPage = this.pageNumber;
      this.activityFilterRequest.editionId = this.editionId;


      this.activityService.getActiveFilteredActivities(this.activityFilterRequest)
        .subscribe(result => {
          this.activities = result.activities;
          this.totalPages = result.totalPages;
          this.pageNumber = result.currentPage;
            }, error => console.error(error));
    }

    deleteActivity() {
        var activityId = 12;

        this.activityService.deleteActivity(activityId)
            .subscribe((result) => {
                console.log(result);
            }, error => console.error(error));
    }

    nextPage() {

    }

    prevPage() {

    }
}
