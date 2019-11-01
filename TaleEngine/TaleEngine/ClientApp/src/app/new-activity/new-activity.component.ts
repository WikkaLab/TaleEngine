import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivityDto } from '../models/activity-dto';
import { HttpHelper } from '../../cross/helpers/http';
import { ActivityTypeModel } from '../models/activitytype-model';
import { TimeSlotModel } from '../models/timeslot-model';

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

    httpClient: HttpClient;
    baseUrl: string;

    editionId: number;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;

        this.editionId = 3;

        this.activityDto = new ActivityDto("", "", 0, "", 0, 0, "", "", 0);

        this.httpClient.get<ActivityTypeModel[]>(this.baseUrl + 'api/ActivityType/GetActivityTypes').subscribe(result => {
            this.activityTypes = result;
            console.log(result);
        });
        this.httpClient.get<TimeSlotModel[]>(this.baseUrl + 'api/TimeSlot/GetTimeSlots').subscribe(result => {
            this.timeSlots = result;
            console.log(result);
        });
    }

    addActivity() {
        this.activityDto.timeSlotId = this.selectedSlot;
        this.activityDto.typeId = this.selectedType;

        console.log(this.activityDto);

        this.httpClient.post<ActivityDto>(this.baseUrl + 'api/Activity/CreateActivity/' + this.editionId,
            JSON.stringify(this.activityDto),
            HttpHelper.JsonHeaderOptions)
            .subscribe((result) => {
                console.log(result);
            }, error => console.error(error));
    }
}
