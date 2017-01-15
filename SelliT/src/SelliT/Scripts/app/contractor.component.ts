import {Component} from "@angular/core";
@Component({
    selector: "contractor",
    template: `
        <h1>{{title}}</h1>
        <contractor-list></contractor-list>
        `
})
export class ContractorComponent {
    title = " Contractors";
}