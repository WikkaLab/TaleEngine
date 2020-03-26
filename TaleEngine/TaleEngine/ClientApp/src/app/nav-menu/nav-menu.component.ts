import { Component, Output } from '@angular/core';
import { EventsService } from '../../services/event-service';
import { EventManagerService } from '../../services/event-manager-service';
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
    eventManager: EventManagerService;

  canManage: boolean;

    constructor(eventService: EventsService, eventManager: EventManagerService) {
      this.eventService = eventService;
      this.eventManager = eventManager;
        this.canManage = true;

        this.eventService.getEvents().subscribe((result: EventModel[]) => {
          this.events = result;
        }, error => console.error(error));
    }

  onEventSelection(selectedEvent) {
    this.getEventActivities(selectedEvent);
    this.eventManager.selectEvent(selectedEvent);
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
