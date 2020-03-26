import { Component } from '@angular/core';
import { ActivityDto } from '../models/activity-dto';
import { ActivityService } from '../../services/activity-service';
import { ActivityFilterRequest } from '../models/requests/activity-filter-request';
import { ActivityFilteredResult } from '../models/activity-filtered-result';
import { EventManagerService } from '../../services/event-manager-service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public activities: ActivityDto[];

  activityService: ActivityService;
  eventManager: EventManagerService;

    pageNumber: number = 1;
    editionId: number = 3;

    totalPages: number = 0;

    activityFilterRequest: ActivityFilterRequest;

    activityFilterResult: ActivityFilteredResult;

    nextPageExists: boolean;
    prevPageExists: boolean;

  constructor(activityService: ActivityService, eventManager: EventManagerService) {
    this.activityService = activityService;
    this.eventManager = eventManager;

      this.activityFilterRequest = new ActivityFilterRequest();
      this.activityFilterRequest.currentPage = this.pageNumber;
      this.activityFilterRequest.editionId = this.editionId;

      this.getActivitiesFiltered();
    }

    deleteActivity() {
        var activityId = 12;

        this.activityService.deleteActivity(activityId)
            .subscribe((result) => {
                console.log(result);
            }, error => console.error(error));
    }

  getActivitiesFiltered() {
    this.activityService.getActiveFilteredActivities(this.activityFilterRequest)
      .subscribe(result => {
        this.activities = result.activities;
        this.totalPages = result.totalPages;
        this.pageNumber = result.currentPage;

        this.checkPageButtons();

      }, error => console.error(error));
  }

  nextPage() {
    this.activityFilterRequest.currentPage = this.pageNumber + 1;

    this.getActivitiesFiltered();
  }

  prevPage() {
    this.activityFilterRequest.currentPage = this.pageNumber - 1;

    this.getActivitiesFiltered();
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
