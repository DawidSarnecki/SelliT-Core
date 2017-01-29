import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions} from "@angular/http";
import {Observable} from "rxjs/Observable";
import {Invoice} from "./invoice";


@Injectable()
export class InvoiceService {

    constructor(private http: Http) { }

    // base web api URL
    private baseUrl = "api/invoices/";

    private handledError(error: Response) {
        // print error in the console
        console.error(error);
        return Observable.throw(error.json().error || "A server error occurred");
    }

    // calls the [GET] /api/invoices/{ID} Web API method to get the item with the giveN ID.
    get(id?: string) {
        if (id == null || id == "") {
            var url = this.baseUrl +"GetAll";
            return this.http.get(url)
                .map(response => <Invoice>response.json())
                .catch(this.handledError);
        }
        else {
            var url = this.baseUrl + id;
            return this.http.get(url)
                .map(response => <Invoice>response.json())
                .catch(this.handledError);
        }
    }

 
  
    // calls the [POST] api/contractors/ Web API method to ADD a new item.
    add(item: Invoice) {
        var url = this.baseUrl;
        return this.http.post(url, JSON.stringify(item), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handledError);
    }


    // calls the [PUT] api/contractors/ Web API method to UPDATE an existing item.
    update(item: Invoice) {
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