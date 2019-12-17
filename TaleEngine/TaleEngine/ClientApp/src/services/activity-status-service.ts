import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivityStatusModel } from "../app/models/activitystatus-model";

@Injectable()
export class ActivityStatusService {
    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;
    }

    public getActivityStatus() {
        return this.httpClient.get<ActivityStatusModel[]>(this.baseUrl + 'api/ActivityStatus/GetActivityStatuses');
    }
}
