import { Inject, Injectable } from "@angular/core";
import { ActivityDto } from "../app/models/activity-dto";
import { HttpHelper } from "../cross/helpers/http";
import { HttpClient } from '@angular/common/http';
import { ActivityChangeStatusDto } from "../app/models/activity-change-status-dto";

@Injectable()
export class ActivityService {
    httpClient: HttpClient;
    baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.baseUrl = baseUrl;
    }

    public createActivity(activityDto: ActivityDto, editionId: number) {
        return this.httpClient.post<ActivityDto>(this.baseUrl + 'api/Activity/CreateActivity/' + editionId,
            JSON.stringify(activityDto),
            HttpHelper.JsonHeaderOptions);
    }

    public getActiveActivities(editionId: number) {
        return this.httpClient.get<ActivityDto[]>(this.baseUrl + 'api/Activity/GetActivities/' + editionId);
    }

    public deleteActivity(activityId: number) {
        return this.httpClient.delete<number>(this.baseUrl + 'api/Activity/DeleteActivity/' + activityId);
    }

    public changeActivityStatus(activityChangeStatusRequest: ActivityChangeStatusDto) {
        return this.httpClient.put<number>(this.baseUrl + 'api/Activity/ChangeActivityStatus',
            JSON.stringify(activityChangeStatusRequest),
            HttpHelper.JsonHeaderOptions);
    }

    public getPendingActivities(editionId: number) {
        return this.httpClient.get<ActivityDto[]>(this.baseUrl + 'api/Activity/GetPendingActivities/' + editionId);
    }
}
