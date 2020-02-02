import { Component } from '@angular/core';
import { ActivityDto } from '../models/activity-dto';
import { ActivityTypeModel } from '../models/activitytype-model';
import { TimeSlotModel } from '../models/timeslot-model';
import { ActivityService } from '../../services/activity-service';
import { TimeSlotsService } from '../../services/time-slots-service';
import { ActivityTypesService } from '../../services/activity-types-service';

@Component({
  selector: 'app-new-activity-component',
  templateUrl: './new-activity.component.html'
})
export class NewActivityComponent {

    activityDto: ActivityDto;

    selectedType: number;
    activityTypes: ActivityTypeModel[];
    selectedSlot: number;
    timeSlots: TimeSlotModel[];

    editionId: number;

    activityService: ActivityService;
    activityTypesService: ActivityTypesService;
    timeSlotsService: TimeSlotsService;

    constructor(activityService: ActivityService, activityTypeService: ActivityTypesService,
        timeSlotsService: TimeSlotsService) {
        this.timeSlotsService = timeSlotsService;
        this.activityTypesService = activityTypeService;

        this.activityService = activityService;

        this.editionId = 3;

        this.activityDto = new ActivityDto(0, "", "", 0, "", 0, 0, "", "", 0);

        this.activityTypesService.getActivityTypes().subscribe(result => {
            this.activityTypes = result;
            console.log(result);
        });
        this.timeSlotsService.getTimeSlots().subscribe(result => {
            this.timeSlots = result;
            console.log(result);
        });
    }

    addActivity() {
        this.activityDto.timeSlotId = this.selectedSlot;
        this.activityDto.typeId = this.selectedType;

        console.log(this.activityDto);

        this.activityService.createActivity(this.activityDto, this.editionId)
            .subscribe((result) => {
                console.log(result);
            }, error => console.error(error));
    }
}
