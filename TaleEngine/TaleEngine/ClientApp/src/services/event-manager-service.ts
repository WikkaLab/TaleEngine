import { Injectable } from "@angular/core";

@Injectable()
export class EventManagerService {
  selectedEvent: number;

  getSelectedEvent() {
    return this.selectedEvent;
  }

  selectEvent(event: number) {
    this.selectedEvent = event;
  }
}
