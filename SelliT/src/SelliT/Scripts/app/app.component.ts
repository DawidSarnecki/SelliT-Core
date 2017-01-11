import {Component} from "@angular/core";
@Component({
    selector: "invoicelist",
    template: `
        <h1>{{title}}</h1>
        <h3>{{subTitle}}</h3>
        <hr>
        <contractor-list></contractor-list>
        `
})
export class AppComponent {
    title = "SelliT";
    subTitle = "invoicing app";
}