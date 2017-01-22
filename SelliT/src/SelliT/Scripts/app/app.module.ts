///<reference path="../../typings/index.d.ts"/>
import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";
import {HttpModule} from "@angular/http";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import "rxjs/Rx";


import {AppRouting} from "./app.routing";
import {AppComponent} from "./app.component";
import {ContractorComponent} from "./contractor.component";
import {ContractorDetailComponent} from "./contractor-detail.component";
import {ContractorListComponent} from "./contractor-list.component";
import {InvoiceComponent} from "./invoice.component";
import {ContractorService} from "./contractor.service";
import {ProductComponent} from "./product.component";
import {ProductDetailComponent} from "./product-detail.component";
import {ProductListComponent} from "./product-list.component";
import {ProductService} from "./product.service";
import {LoginComponent} from "./login.component"; 
import {PageNotFoundComponent} from "./page-not-found.component";
import {UserComponent} from "./user.component";
import {UserDetailComponent} from "./user-detail.component";
import {UserListComponent} from "./user-list.component";
import {UserService} from "./user.service";

@NgModule({

    // directives, components, and pipes
    declarations: [
        AppComponent,
        ContractorComponent,
        ContractorListComponent,
        ContractorDetailComponent,
        InvoiceComponent,
        ProductComponent,
        ProductListComponent,
        ProductDetailComponent,
        LoginComponent,
        UserComponent,
        UserListComponent,
        UserDetailComponent,
        PageNotFoundComponent
    ],

    // modules
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        RouterModule,
        AppRouting
    ],

    // providers
    providers: [
        ContractorService,
        ProductService,
        UserService

    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }