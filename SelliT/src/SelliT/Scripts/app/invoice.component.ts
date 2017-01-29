import {Component} from "@angular/core";
@Component({
    selector: "invoice",
    template: `
        <h3><a class="add" [routerLink]="['new']"> + New invoice</a></h3>
        <invoice-list></invoice-list>
        `
})
export class InvoiceComponent {
}