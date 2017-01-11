import {Component} from "@angular/core";
@Component({
    selector: "invoicelist",
    template: `
        <h1>{{title}}</h1>
        <contractor-list></contractor-list>
        `
})
export class AppComponent {
    title = "List of Contractors";
}