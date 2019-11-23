import { Inject, Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { TimeSlotModel } from "../app/models/timeslot-model";

@Injectable()
export class TimeSlotsService {
    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;
    }

    public getTimeSlots() {
        return this.httpClient.get<TimeSlotModel[]>(this.baseUrl + 'api/TimeSlot/GetTimeSlots');
    }
}
