import { HttpHeaders } from "@angular/common/http";

export class HttpHelper {

    public static readonly JsonHeaderOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
}
