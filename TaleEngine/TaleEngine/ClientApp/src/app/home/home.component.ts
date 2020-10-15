import { Component } from '@angular/core';
import { ActivityService } from '../../services/activity-service';
import { ActivityDto } from '../models/activity-dto';
import { EventsService } from '../../services/event-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  editionId: number;
  lastActivities: ActivityDto[];

  activityService: ActivityService;
  eventService: EventsService;

  constructor(activityService: ActivityService,
    eventService: EventsService) {
    this.activityService = activityService;
    this.eventService = eventService;

    this.editionId = 3; //this.eventService.getSelectedEvent();
    //this.getEdition();
    this.getLastThreeActivities();
  }

  getLastThreeActivities() {
    this.activityService.getThreeLastActiveActivities(this.editionId)
      .subscribe(result => {
        this.lastActivities = result
        console.log(this.lastActivities);
      },
        error => console.error(error)
      );
  }
}
