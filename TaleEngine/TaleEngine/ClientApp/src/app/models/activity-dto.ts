export class ActivityDto {
    title: string;
    description: string;
    places: number;

    constructor(title: string, description: string, places: number) {
        this.title = title;
        this.description = description;
        this.places = places;
    }
}
