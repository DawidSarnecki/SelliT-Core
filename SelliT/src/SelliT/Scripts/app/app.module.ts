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
import {ContractorService} from "./contractor.service";
import {LoginComponent} from "./login.component"; 
import {PageNotFoundComponent} from "./page-not-found.component";

@NgModule({

    // directives, components, and pipes
    declarations: [
        AppComponent,
        ContractorComponent,
        ContractorListComponent,
        ContractorDetailComponent,
        LoginComponent,
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
        ContractorService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }