export class ActivityChangeStatusDto {
    activityId: number;
    statusId: number;

    constructor(activityId: number, statusId: number) {
        this.activityId = activityId;
        this.statusId = statusId;
    }
}
