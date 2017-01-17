import {Component} from "@angular/core";
@Component({
    selector: "sellitapp",
    template: `
        <h1>{{title}}</h1>
        <h3>{{subTitle}}</h3>
        <hr>
        <div>
            <h4>
            | <a class="add" [routerLink]="['invoice', 'new']"> + New Invoice</a>
            | <a class="invoice" [routerLink]="['invoice']">Invoices</a>
            | <a class="contractor" [routerLink]="['contractor']">Contractors</a>
            | <a class="product" [routerLink]="['product']">Products</a>
            | <a class="settings" [routerLink]="['settings']">Settings</a>
            | <a class="login" [routerLink]="['login']">Login</a>
            </h4>
        </div>
        <hr>
        <router-outlet></router-outlet>
        `
})
export class AppComponent {
    title = "SelliT";
    subTitle = "invoicing app";
}