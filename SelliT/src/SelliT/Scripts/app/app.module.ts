﻿///<reference path="../../typings/index.d.ts"/>
import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";
import {HttpModule} from "@angular/http";
import {FormsModule} from "@angular/forms";
import "rxjs/Rx";
import {AppComponent} from "./app.component";
import {ContractorDetailComponent} from "./contractor-detail.component";
import {ContractorListComponent} from "./contractor-list.component";
import {ContractorService} from "./contractor.service";


@NgModule({

    // directives, components, and pipes
    declarations: [
        AppComponent,
        ContractorListComponent,
        ContractorDetailComponent
    ],

    // modules
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule

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