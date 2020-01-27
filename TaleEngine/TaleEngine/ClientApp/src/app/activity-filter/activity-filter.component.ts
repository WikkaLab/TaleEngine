import { Component } from '@angular/core';
import { ActivityTypesService } from '../../services/activity-types-service';
import { ActivityStatusService } from '../../services/activity-status-service';

import { ActivityTypeModel } from '../models/activitytype-model';
import { ActivityStatusModel } from '../models/activitystatus-model';

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

    constructor(activityStatusService: ActivityStatusService, activityTypeService: ActivityTypesService) {
        this.activityTypesService = activityTypeService;
        this.activityStatusService = activityStatusService;


        this.activityTypesService.getActivityTypes().subscribe(result => {
            this.activityTypes = result;
        });
        this.activityStatusService.getActivityStatus().subscribe(result => {
            this.activityStatuses = result;
        });

    }

    searchActivities() {
        console.log('start search');
    }

    onStatusSelection(status: number) {
        console.log('selected status: ' + status);
    }

    onTypeSelection(type: number) {
        console.log('selected type: ' + type);
    }

}
