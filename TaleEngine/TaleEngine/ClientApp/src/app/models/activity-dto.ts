export class ActivityDto {
    title: string;
    description: string;
    places: number;
    image: string;

    timeSlotId: number;

    //activityStart: Date;
    //activityEnd: Date;

    typeId: number;
    statusId: number;


    constructor(title: string, description: string, places: number, image: string,
        typeId: number, timeSlotId: number, activityStart: Date, activityEnd: Date,
        statusId: number) {
        this.title = title;
        this.description = description;
        this.places = places;

        //this.activityStart = activityStart;
        //this.activityEnd = activityEnd;

        this.typeId = typeId;
        this.timeSlotId = timeSlotId
        this.statusId = statusId;
    }
}
