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

    nextPageExists: boolean;
    prevPageExists: boolean;

  //deleteActivity() {
  //  var activityId = 12;

  //  this.activityService.deleteActivity(activityId)
  //    .subscribe((result) => {
  //      console.log(result);
  //    }, error => console.error(error));
  //}

  onActivityFilterResult(activityFilterResult: ActivityFilteredResult) {
    console.log("Getting results...");

    this.activities = activityFilterResult.activities;
    this.totalPages = activityFilterResult.totalPages;
    this.pageNumber = activityFilterResult.currentPage;

    this.checkPageButtons();
  }

  nextPage() {
    this.activityFilterRequest.currentPage = this.pageNumber + 1;
  }

  prevPage() {
    this.activityFilterRequest.currentPage = this.pageNumber - 1;
  }

  checkPageButtons() {
    this.checkPrevPageExists();
    this.checkNextPageExists();
  }

  checkPrevPageExists() {
    this.nextPageExists = this.pageNumber != this.totalPages;
  }

  checkNextPageExists() {
    this.prevPageExists = this.pageNumber > 1;
  }
}
