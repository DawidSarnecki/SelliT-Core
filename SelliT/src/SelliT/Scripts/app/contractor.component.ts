import {Component} from "@angular/core";
@Component({
    selector: "contractor",
    template: `
        <h2>{{title}}</h2>
        <h3><a class="add" [routerLink]="['new']"> + New contractor</a></h3>
        <contractor-list></contractor-list>
        `
})
export class ContractorComponent {
    title = " Contractors";
}