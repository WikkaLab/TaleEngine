import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivityTypeModel } from "../app/models/activitytype-model";


@Injectable()
export class ActivityTypesService {
    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;
    }

    public getActivityTypes() {
        return this.httpClient.get<ActivityTypeModel[]>(this.baseUrl + 'api/ActivityType/GetActivityTypes');
    }
}
