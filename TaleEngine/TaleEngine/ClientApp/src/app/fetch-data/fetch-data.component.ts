import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventModel } from '../models/event-model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public events: EventModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EventModel[]>(baseUrl + 'api/Event/GetEvents').subscribe(result => {
      this.events = result;
    }, error => console.error(error));
  }
}
