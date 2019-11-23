import { Inject, Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { EventModel } from "../app/models/event-model";

@Injectable()
export class EventsService {
    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;
    }

    public getEvents() {
        return this.httpClient.get<EventModel[]>(this.baseUrl + 'api/Event/GetEvents');
    }
}
