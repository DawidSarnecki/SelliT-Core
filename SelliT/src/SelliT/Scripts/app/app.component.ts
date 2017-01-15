import {Component} from "@angular/core";
@Component({
    selector: "sellitapp",
    template: `
        <div>
            <a class="contractor" [routerLink]="['contractor']">Contractors</a>
            | <a class="add" [routerLink]="['contractor', 'new']"> + New contractor</a>
            | <a class="login" [routerLink]="['login']">Login</a>
        </div>
        <router-outlet></router-outlet>
        `
})
export class AppComponent {
    title = "SelliT";
    subTitle = "invoicing app";
}