import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions} from "@angular/http";
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

    // calls the [GET] /api/contractors/{ID} Web API method 
    // to get the item with the given ID or all items if ID is empty.
    get(id?: string) {
        if (id == null || id == "") {
            var url = this.baseUrl;
            return this.http.get(url)
                .map(response => <Contractor>response.json())
                .catch(this.handledError);
        }
        else {
            var url = this.baseUrl + id;
            return this.http.get(url)
                .map(response => <Contractor>response.json())
                .catch(this.handledError);
        }

    }


    // calls the [GET] /api/contractors/GetLatest/{n} Web API method to get the n items.
    getLatest(num?: number) {
        var url = this.baseUrl + "GetLatest/";
        if (num != null) { url += num; }
        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handledError);
    }

    // calls the [POST] api/contractors/ Web API method to ADD a new item.
    add(item: Contractor) {
        var url = this.baseUrl;
        return this.http.post(url, JSON.stringify(item), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handledError);
    }


    // calls the [PUT] api/contractors/ Web API method to UPDATE an existing item.
    update(item: Contractor) {
        var url = this.baseUrl + item.ID;
        return this.http.put(url, JSON.stringify(item), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handledError);
    }

    // calls the [DELETE] api/contractors/ Web API method to DELETE an item with given ID.
    delete(id: string) {
        var url = this.baseUrl + id;
        return this.http.delete(url)
            .catch(this.handledError);
    }

    // return RequestOptions object to handle Json requests
    private getRequestOptions() {
        return new RequestOptions({
            headers: new Headers({ "Content-Type": "application/json" })
        });
    }
}