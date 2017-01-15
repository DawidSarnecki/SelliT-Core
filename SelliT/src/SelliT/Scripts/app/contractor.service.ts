import {Injectable} from "@angular/core";
import {Http, Response} from "@angular/http";
import {Observable} from "rxjs/Observable";
import {Contractor} from "./contractor";

@Injectable()
export class ContractorService {
    constructor(private http: Http) { }

    // base web api URL
    private baseUrl = "api/contractors/";

    private handledError(error: Response) {
        // print error in the console
        console.error(error);
        return Observable.throw(error.json().error || "A server error occurred");
    }

    // calls the [GET] /api/contractors/GetLatest/{n} Web API method to get the n items.
    getLatest(num?: number) {
        var url = this.baseUrl + "GetLatest/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handledError);
    }

    // calls the [GET] /api/contractors/{ID} Web API method to get the item with the give ID.
    get(id?: number) {
        if (id == null) { throw new Error("ID is required!"); }
        var url = this.baseUrl + id;
        return this.http.get(url)
            .map(response => <Contractor>response.json())
            .catch(this.handledError);
    }

}