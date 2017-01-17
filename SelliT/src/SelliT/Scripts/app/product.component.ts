import {Component} from "@angular/core";
@Component({
    selector: "product",
    template: `
        <h3><a class="add" [routerLink]="['new']"> + New Product</a></h3>
        <product-list></product-list>
        `
})
export class ProductComponent {}