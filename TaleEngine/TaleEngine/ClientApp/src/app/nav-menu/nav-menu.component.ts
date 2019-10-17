import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHelper } from '../../cross/helpers/http';
import { EventModel } from '../models/event-model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

    events: EventModel[];
    selectedEvent: EventModel;

    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;

        this.httpClient.get<EventModel[]>(this.baseUrl + 'api/Event/GetEvents').subscribe((result: EventModel[]) => {
            this.events = result;
        }, error => console.error(error));
    }

    onEventSelection(selectedValue) {
        this.getEventActivities(selectedValue);
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
