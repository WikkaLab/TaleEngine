import { Component, EventEmitter, Output, Input } from '@angular/core';
import { ActivityTypesService } from '../../services/activity-types-service';
import { ActivityStatusService } from '../../services/activity-status-service';

import { ActivityTypeModel } from '../models/activitytype-model';
import { ActivityStatusModel } from '../models/activitystatus-model';
import { ActivityService } from '../../services/activity-service';
import { ActivityFilterRequest } from '../models/requests/activity-filter-request';
import { ActivityFilteredResult } from '../models/activity-filtered-result';

@Component({
  selector: 'app-activity-filter',
  templateUrl: './activity-filter.component.html',
})
export class ActivityFilterComponent {

    activityTypes: ActivityTypeModel[];
    activityStatuses: ActivityStatusModel[];

    selectedType: ActivityTypeModel;
    selectedStatus: ActivityStatusModel; 

    activityTypesService: ActivityTypesService;
  activityStatusService: ActivityStatusService;

  titleToSearch: string;

  activityService: ActivityService;

  activityFilterRequest: ActivityFilterRequest;

  @Input() pageNumber: number;
  @Input() editionId: number;

  @Output() activityFilterResult = new EventEmitter<ActivityFilteredResult>();

  constructor(activityStatusService: ActivityStatusService, activityTypeService: ActivityTypesService, activityService: ActivityService) {
    this.activityTypesService = activityTypeService;
    this.activityStatusService = activityStatusService;

    this.activityService = activityService;

    this.activityTypesService.getActivityTypes().subscribe(result => {
      this.activityTypes = result;
    });
    this.activityStatusService.getActivityStatus().subscribe(result => {
      this.activityStatuses = result;
    });
    this.searchActivities();
  }

  searchActivities() {
    console.log("Searching...");

    this.activityFilterRequest = new ActivityFilterRequest();
    this.activityFilterRequest.currentPage = this.pageNumber;
    this.activityFilterRequest.editionId = this.editionId;
    this.activityFilterRequest.title = this.titleToSearch;
    this.activityFilterRequest.typeId = this.selectedType ? this.selectedType.id : 0;

    this.activityService.getActiveFilteredActivities(this.activityFilterRequest)
      .subscribe(result => {
        if (result) {
          this.activityFilterResult.emit(result);
        }
      }, error => console.error(error));
    }

  onStatusSelection(status: number) {
    //this.activityFilterRequest.stat = status;
  }

  onTypeSelection(type: number) {
    this.activityFilterRequest.typeId = type;
  }

}
