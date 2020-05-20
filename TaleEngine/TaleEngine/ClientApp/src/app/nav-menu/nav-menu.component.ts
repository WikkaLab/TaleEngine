import { Component, Output } from '@angular/core';
import { EventsService } from '../../services/event-service';
import { EventModel } from '../models/event-model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  events: EventModel[];
  selectedEvent: EventModel;

  eventService: EventsService;

  canManage: boolean;

  constructor(eventService: EventsService) {
    this.eventService = eventService;
    this.canManage = true;

    this.eventService.getEvents().subscribe((result: EventModel[]) => {
      this.events = result;
    }, error => console.error(error));
  }

  onEventSelection(selectedEvent) {
    //this.getEventActivities(selectedEvent);
    this.eventService.selectEvent(selectedEvent);
  }

  getEventActivities(selectedEventId) {
    console.log("Getting activities of event " + selectedEventId);
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
