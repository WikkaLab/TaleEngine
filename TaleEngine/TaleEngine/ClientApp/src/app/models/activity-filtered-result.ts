import { ActivityDto } from "./activity-dto";

export class ActivityFilteredResult {
  currentPage: number;
  totalPages: number;
  activities: ActivityDto[];
}
